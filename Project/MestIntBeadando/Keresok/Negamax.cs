using MestIntBeadando.AllapotTer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestIntBeadando.Keresok
{
    class Negamax
    {
        int maxMelyseg = 2;

        public Operator Ajanl(Allapot allapot)
        {
            List<Operator> ajanlottOperator = new List<Operator>();

            for (int i = 0; i < Allapot.OSZLOP; i++)
            {
                for (int j = 0; j < Allapot.SOR; j++)
                {
                    Operator aktualisOperator = new Operator(new Point(i, j), allapot.Jatekos);
                    if (aktualisOperator.Elofeltetel(allapot))
                    {
                        Allapot ujAllapot = aktualisOperator.Lepes(allapot);
                        Bejaras(ujAllapot, aktualisOperator, 0, 1);
                        ajanlottOperator.Add(aktualisOperator);
                    }
                }
            }

            ajanlottOperator = ajanlottOperator.OrderByDescending(o => o.Suly).ToList();

            return ajanlottOperator[0];
        }

        private void Bejaras(Allapot aktualisAllapot, Operator eredetiOperator, int melyseg, int elojel)
        {
            if (aktualisAllapot.Celfeltetel() == "X" || aktualisAllapot.Celfeltetel() == "O")
            {
                eredetiOperator.Suly = elojel * aktualisAllapot.Heurisztika();
            }
            else
            {
                if (aktualisAllapot.Celfeltetel() != "Dontetlen" && melyseg < maxMelyseg)
                {
                    int max = Int32.MinValue;
                    for (int i = 0; i < Allapot.OSZLOP; i++)
                    {
                        for (int j = 0; j < Allapot.SOR; j++)
                        {
                            Operator aktualisOperator = new Operator(new Point(i, j), aktualisAllapot.Jatekos);
                            if (aktualisOperator.Elofeltetel(aktualisAllapot))
                            {
                                Allapot allapot = aktualisOperator.Lepes(aktualisAllapot);
                                int aktualisSuly = elojel * allapot.Heurisztika();
                                if (aktualisSuly > max)
                                {
                                    max = aktualisSuly;
                                }
                                Bejaras(allapot, eredetiOperator, melyseg + 1, elojel * -1);
                            }
                        }
                    }
                    eredetiOperator.Suly += max;
                }
            }
        }
    }
}

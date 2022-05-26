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
        int maxDepth = 2;

        public Operator Ajanl(Allapot allapot)
        {
            List<Operator> ajanlottOperator = new List<Operator>();

            for (int i = 0; i < Allapot.COLUMN_COUNT; i++)
            {
                for (int j = 0; j < Allapot.ROW_COUNT; j++)
                {
                    Operator actualOperator = new Operator(new Point(i, j), allapot.Player);
                    if (actualOperator.Elofeltetel(allapot))
                    {
                        Allapot ujAllapot = actualOperator.Lepes(allapot);
                        Bejaras(ujAllapot, actualOperator, 0, 1);
                        ajanlottOperator.Add(actualOperator);
                    }
                }
            }

            ajanlottOperator = ajanlottOperator.OrderByDescending(o => o.Weight).ToList();

            return ajanlottOperator[0];
        }

        private void Bejaras(Allapot aktualisAllapot, Operator originalOperator, int depth, int sign)
        {
            if (aktualisAllapot.Celfeltetel() == "X" || aktualisAllapot.Celfeltetel() == "O")
            {
                originalOperator.Weight = sign * aktualisAllapot.Heurisztika();
            }
            else
            {
                if (aktualisAllapot.Celfeltetel() != "Draw" && depth < maxDepth)
                {
                    int max = Int32.MinValue;
                    for (int i = 0; i < Allapot.COLUMN_COUNT; i++)
                    {
                        for (int j = 0; j < Allapot.ROW_COUNT; j++)
                        {
                            Operator actualOperator = new Operator(new Point(i, j), aktualisAllapot.Player);
                            if (actualOperator.Elofeltetel(aktualisAllapot))
                            {
                                Allapot allapot = actualOperator.Lepes(aktualisAllapot);
                                int actualWeight = sign * allapot.Heurisztika();
                                if (actualWeight > max)
                                {
                                    max = actualWeight;
                                }
                                Bejaras(allapot, originalOperator, depth + 1, sign * -1);
                            }
                        }
                    }
                    originalOperator.Weight += max;
                }
            }
        }
    }
}

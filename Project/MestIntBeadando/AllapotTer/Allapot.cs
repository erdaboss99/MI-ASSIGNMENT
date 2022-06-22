using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestIntBeadando.AllapotTer
{
    class Allapot
    {
        public static int SOR = 3;
        public static int OSZLOP = 3;
        private string jatekos;
        private string[,] palya;

        public string Jatekos
        {
            get { return jatekos; }
            set { jatekos = value; }
        }

        public string[,] Palya
        {
            get { return palya; }
            set { palya = value; }
        }

        public Allapot()
        {
            this.Jatekos = "X";
            this.Palya = new string[SOR, OSZLOP];
        }

        public string Celfeltetel()
        {
            //Horizontal 3
            for (int i = 0; i < SOR; i++)
            {
                if (palya[i, 0] != null && palya[i, 0] == palya[i, 1] && palya[i, 1] == palya[i, 2])
                {
                    return palya[i, 0];
                }
            }

            //Vertical 3
            for (int i = 0; i < OSZLOP; i++)
            {
                if (palya[0, i] != null && palya[0, i] == palya[1, i] && palya[1, i] == palya[2, i])
                {
                    return palya[0, i];
                }
            }

            //Main diagonal
            if (palya[0, 0] != null && palya[0, 0] == palya[1, 1] && palya[1, 1] == palya[2, 2])
            {
                return palya[0, 0];
            }

            //Counter diagonal
            if (palya[0, 2] != null && palya[0, 2] == palya[1, 1] && palya[1, 1] == palya[2, 0])
            {
                return palya[0, 2];
            }

            //Possible steps are available
            for (int i = 0; i < SOR; i++)
            {
                for (int j = 0; j < OSZLOP; j++)
                {
                    if (palya[i, j] == null)
                    {
                        return null;
                    }
                }
            }
            //döntetlen
            return "Dontetlen";
        }

        public int Heurisztika()
        {
            int suly = 0;
            if (Celfeltetel() == "O")
            {
                return 100;
            }
            if (Celfeltetel() == "X")
            {
                return 80;
            }

            for (int i = 0; i < Allapot.OSZLOP; i++)
            {
                for (int j = 0; j < Allapot.SOR; j++)
                {
                    if (palya[i, j] == Jatekos)
                    {
                        if (i + 1 < 3 && palya[i + 1, j] == Jatekos)
                        {
                            suly += 5;
                        }
                        if (j + 1 < 3 && palya[i, j + 1] == Jatekos)
                        {
                            suly += 5;
                        }
                        if (i + 1 < 3 && j + 1 < 3 && palya[i + 1, j + 1] == Jatekos)
                        {
                            suly += 5;
                        }
                        if (i - 1 >= 0 && j - 1 >= 0 && palya[i - 1, j - 1] == Jatekos)
                        {
                            suly += 5;
                        }
                    }
                }
            }
            return suly;
        }

    }
}

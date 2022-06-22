using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestIntBeadando.AllapotTer
{
    class Operator
    {
        private string mit;
        private Point hova;
        private int suly;

        public string Mit
        {
            get { return mit; }
            set { mit = value; }
        }

        public Point Hova
        {
            get { return hova; }
            set { hova = value; }
        }

        public int Suly
        {
            get { return suly; }
            set { suly = value; }
        }

        public Operator(Point hova, string mit)
        {
            this.Hova = hova;
            this.Mit = mit;
        }

        public bool Elofeltetel(Allapot aktualisAllapot)
        {
            return aktualisAllapot.Palya[Hova.X, Hova.Y] == null;
        }

        public Allapot Lepes(Allapot aktualisAllapot)
        {
            Allapot ujAllapot = new Allapot();
            ujAllapot.Palya = (string[,])aktualisAllapot.Palya.Clone();

            ujAllapot.Palya[Hova.X, Hova.Y] = Mit;
            if (Mit == "X")
            {
                ujAllapot.Jatekos = "O";
            }
            else
            {
                ujAllapot.Jatekos = "X";
            }
            return ujAllapot;
        }
    }
}

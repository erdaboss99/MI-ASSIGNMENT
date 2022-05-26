using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestIntBeadando.AllapotTer
{
    class Operator
    {
        private string what;
        private Point where;
        private int weight;

        public string What
        {
            get { return what; }
            set { what = value; }
        }

        public Point Where
        {
            get { return where; }
            set { where = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Operator(Point where, string what)
        {
            this.Where = where;
            this.What = what;
        }

        public bool Elofeltetel(Allapot aktualisAllapot)
        {
            return aktualisAllapot.GameField[Where.X, Where.Y] == null;
        }

        public Allapot Lepes(Allapot aktualisAllapot)
        {
            Allapot ujAllapot = new Allapot();
            ujAllapot.GameField = (string[,])aktualisAllapot.GameField.Clone();

            ujAllapot.GameField[Where.X, Where.Y] = What;
            if (What == "X")
            {
                ujAllapot.Player = "O";
            }
            else
            {
                ujAllapot.Player = "X";
            }
            return ujAllapot;
        }
    }
}

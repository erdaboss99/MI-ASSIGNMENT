using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestIntBeadando.AllapotTer
{
    class Mezo : Button
    {
        private Point point;

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        public Mezo(int x, int y)
        {
            this.Point = new Point(x, y);
            this.Size = new Size(100, 100);
            this.Font = new Font(this.Font.FontFamily, 20, FontStyle.Bold);
        }
    }
}

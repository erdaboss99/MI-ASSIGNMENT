using MestIntBeadando.AllapotTer;
using MestIntBeadando.Keresok;

namespace MestIntBeadando
{
    public partial class Form1 : Form
    {
        Mezo[,] palya = new Mezo[Allapot.SOR, Allapot.OSZLOP];
        Allapot allapot;

        public Form1()
        {
            allapot = new Allapot();
            InitializeComponent();
            for (int i = 0; i < Allapot.SOR; i++)
            {
                for (int j = 0; j < Allapot.OSZLOP; j++)
                {
                    Mezo mezo = new Mezo(i, j);
                    mezo.Location = new Point(i * 100, j * 100);
                    mezo.Click += new EventHandler(mezoClick);
                    palya[i, j] = mezo;
                    Controls.Add(mezo);
                }
            }
        }

        private void mezoClick(object sender, EventArgs e)
        {
            Mezo mezo = (Mezo)sender;

            Point point = mezo.Pont;

            Operator op = new Operator(point, allapot.Jatekos);
            if (op.Elofeltetel(allapot))
            {
                Kirajzol(mezo);
                allapot = op.Lepes(allapot);
                CelfeltetelVizsgalat();

                Negamax negaMax = new Negamax();
                Operator opGep = negaMax.Ajanl(allapot);

                Mezo mezoGep = palya[opGep.Hova.X, opGep.Hova.Y];
                Kirajzol(mezoGep);
                allapot = opGep.Lepes(allapot);
                CelfeltetelVizsgalat();

            }
        }

        private void CelfeltetelVizsgalat()
        {
            if (allapot.Celfeltetel() != null)
            {
                if (allapot.Celfeltetel() == "Dontetlen")
                {
                    MessageBox.Show(allapot.Celfeltetel());
                }
                else
                {
                    MessageBox.Show("Gratulalok! Nyertes: " + allapot.Celfeltetel());
                }
                this.Close();
                Application.Exit();
            }
        }

        private void Kirajzol(Mezo mezo)
        {
            mezo.Text = allapot.Jatekos;
            if (allapot.Jatekos == "X")
            {
                mezo.ForeColor = Color.Blue;
            }
            else
            {
                mezo.ForeColor = Color.Yellow;
            }
        }
    }
}
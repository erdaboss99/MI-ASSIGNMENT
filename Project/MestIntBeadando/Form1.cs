using MestIntBeadando.AllapotTer;
using MestIntBeadando.Keresok;

namespace MestIntBeadando
{
    public partial class Form1 : Form
    {
        Mezo[,] gameField = new Mezo[Allapot.ROW_COUNT, Allapot.COLUMN_COUNT];
        Allapot allapot;

        public Form1()
        {
            allapot = new Allapot();
            InitializeComponent();
            for (int i = 0; i < Allapot.ROW_COUNT; i++)
            {
                for (int j = 0; j < Allapot.COLUMN_COUNT; j++)
                {
                    Mezo mezo = new Mezo(i, j);
                    mezo.Location = new Point(i * 100, j * 100);
                    mezo.Click += new EventHandler(mezoClick);
                    gameField[i, j] = mezo;
                    Controls.Add(mezo);
                }
            }
        }

        private void mezoClick(object sender, EventArgs e)
        {
            Mezo mezo = (Mezo)sender;

            Point point = mezo.Point;

            Operator op = new Operator(point, allapot.Player);
            if (op.Elofeltetel(allapot))
            {
                Kirajzol(mezo);
                allapot = op.Lepes(allapot);
                CelfeltetelVizsgalat();

                Negamax negaMax = new Negamax();
                Operator opComputer = negaMax.Ajanl(allapot);

                Mezo mezoGep = gameField[opComputer.Where.X, opComputer.Where.Y];
                Kirajzol(mezoGep);
                allapot = opComputer.Lepes(allapot);
                CelfeltetelVizsgalat();

            }
        }

        private void CelfeltetelVizsgalat()
        {
            if (allapot.Celfeltetel() != null)
            {
                if (allapot.Celfeltetel() == "Draw")
                {
                    MessageBox.Show(allapot.Celfeltetel());
                }
                else
                {
                    MessageBox.Show("Congratulations! Winner: " + allapot.Celfeltetel());
                }
                this.Close();
                Application.Exit();
            }
        }

        private void Kirajzol(Mezo mezo)
        {
            mezo.Text = allapot.Player;
            if (allapot.Player == "X")
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
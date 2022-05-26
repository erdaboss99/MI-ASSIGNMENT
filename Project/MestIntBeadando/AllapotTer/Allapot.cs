using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MestIntBeadando.AllapotTer
{
    class Allapot
    {
        public static int ROW_COUNT = 3;
        public static int COLUMN_COUNT = 3;

        private string player;

        private string[,] gameField;

        public string Player
        {
            get { return player; }
            set { player = value; }
        }

        public string[,] GameField
        {
            get { return gameField; }
            set { gameField = value; }
        }

        public Allapot()
        {
            this.Player = "X";
            this.GameField = new string[ROW_COUNT, COLUMN_COUNT];
        }

        public string Celfeltetel()
        {
            //Horizontal 3
            for (int i = 0; i < ROW_COUNT; i++)
            {
                if (gameField[i, 0] != null && gameField[i, 0] == gameField[i, 1] && gameField[i, 1] == gameField[i, 2])
                {
                    return gameField[i, 0];
                }
            }

            //Vertical 3
            for (int i = 0; i < COLUMN_COUNT; i++)
            {
                if (gameField[0, i] != null && gameField[0, i] == gameField[1, i] && gameField[1, i] == gameField[2, i])
                {
                    return gameField[0, i];
                }
            }

            //Main diagonal
            if (gameField[0, 0] != null && gameField[0, 0] == gameField[1, 1] && gameField[1, 1] == gameField[2, 2])
            {
                return gameField[0, 0];
            }

            //Counter diagonal
            if (gameField[0, 2] != null && gameField[0, 2] == gameField[1, 1] && gameField[1, 1] == gameField[2, 0])
            {
                return gameField[0, 2];
            }

            //Possible steps are available
            for (int i = 0; i < ROW_COUNT; i++)
            {
                for (int j = 0; j < COLUMN_COUNT; j++)
                {
                    if (gameField[i, j] == null)
                    {
                        return null;
                    }
                }
            }
            //döntetlen
            return "Draw";
        }

        public int Heurisztika()
        {
            int weight = 0;
            if (Celfeltetel() == "O")
            {
                return 100;
            }
            if (Celfeltetel() == "X")
            {
                return 80;
            }

            for (int i = 0; i < Allapot.COLUMN_COUNT; i++)
            {
                for (int j = 0; j < Allapot.ROW_COUNT; j++)
                {
                    if (gameField[i, j] == Player)
                    {
                        if (i + 1 < 3 && gameField[i + 1, j] == Player)
                        {
                            weight += 5;
                        }
                        if (j + 1 < 3 && gameField[i, j + 1] == Player)
                        {
                            weight += 5;
                        }
                        if (i + 1 < 3 && j + 1 < 3 && gameField[i + 1, j + 1] == Player)
                        {
                            weight += 5;
                        }
                        if (i - 1 >= 0 && j - 1 >= 0 && gameField[i - 1, j - 1] == Player)
                        {
                            weight += 5;
                        }
                    }
                }
            }
            return weight;
        }

    }
}

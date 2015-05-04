namespace KingSurvival.Models
{
    using System;
    using Enumerations;

    public class Board
    {
        public Board(int boardWidth, int boardHeight)
        {
            this.Field = new int[boardWidth, boardHeight];
            this.King = new King(GameConstants.KingStartPositionX, GameConstants.KingStartPositionY, (char)FigureSymbols.King);
            this.PawnA = new Pawn(GameConstants.PawnAStartPositionX, GameConstants.PawnsStartPositionY, (char)FigureSymbols.PawnA);
            this.PawnB = new Pawn(GameConstants.PawnBStartPositionX, GameConstants.PawnsStartPositionY, (char)FigureSymbols.PawnB);
            this.PawnC = new Pawn(GameConstants.PawnCStartPositionX, GameConstants.PawnsStartPositionY, (char)FigureSymbols.PawnC);
            this.PawnD = new Pawn(GameConstants.PawnDStartPositionX, GameConstants.PawnsStartPositionY, (char)FigureSymbols.PawnD);
            this.InitializeField();
        }

        public int[,] Field { get; set; }
        public King King { get; set; }
        public Pawn PawnA { get; set; }
        public Pawn PawnB { get; set; }
        public Pawn PawnC { get; set; }
        public Pawn PawnD { get; set; }

        public void InitializeField()
        {
            InsertEmptyCells();
            InsertFigures();
        }

        public void PrintBoard()
        {
            string rowNumbers = "0 1 2 3 4 5 6 7";
            string underscore = string.Format("{0}", new String('_', 17));
            string fieldBeginning = string.Format("UL{2}{0}{2}UR\n{2} {1}", rowNumbers, underscore, new String(' ', 2));
            string fieldEnd = string.Format("DL{1}{0}{1}DR\n{1}", rowNumbers, new String(' ', 2));

            Console.WriteLine(fieldBeginning);
            for (int row = 0; row < this.Field.GetLength(0); row++)
            {
                string rowBeginning = string.Format("{0} | ", row);
                string rowEnd = string.Format("| {0}", row);

                Console.Write(rowBeginning);
                for (int column = 0; column < this.Field.GetLength(1); column++)
                {
                    char symbol = (char)this.Field[row, column];
                    Console.Write(symbol.ToString() + ' ');
                }

                Console.Write(rowEnd + "\n");
            }

            Console.WriteLine(string.Format("{0}{1}{2}{1}{0}", new String(' ', 2), '|', underscore) + "\n" + fieldEnd);
        }

        private void InsertFigures()
        {
            this.Field[this.King.PositionY, this.King.PositionX] = this.King.Symbol;
            this.Field[this.PawnA.PositionY, this.PawnA.PositionX] = this.PawnA.Symbol;
            this.Field[this.PawnB.PositionY, this.PawnB.PositionX] = this.PawnB.Symbol;
            this.Field[this.PawnC.PositionY, this.PawnC.PositionX] = this.PawnC.Symbol;
            this.Field[this.PawnD.PositionY, this.PawnD.PositionX] = this.PawnD.Symbol;
        }

        private void InsertEmptyCells()
        {
            for (int row = 0; row < this.Field.GetLength(0); row++)
            {
                for (int column = 0; column < this.Field.GetLength(1); column++)
                {
                    if ((row + column) % 2 == 1)
                    {
                        this.Field[row, column] = (char)BoardSymbols.Unavailable;
                    }
                    else
                    {
                        this.Field[row, column] = (char)BoardSymbols.Available;
                    }
                }
            }
        }
    }
}

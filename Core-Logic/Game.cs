namespace KingSurvival
{
    using System;
    using Enumerations;
    using Models;

    public class Game
    {
        public Game(Board board)
        {
            this.Board = board;
            this.Turns = 0;
        }

        public int Turns { get; set; }
        public Board Board { get; set; }

        public void Run()
        {
            while (CheckIfKingWon() || CheckIfKingLost())
            {
                string command;
                this.Board.InitializeField();
                this.Board.PrintBoard();

                if (this.Turns % 2 == 0)
                {
                    Console.Write("King's turn: ");
                    command = Console.ReadLine();
                    this.ProcessKingCommand(command);
                }
                else
                {
                    Console.Write("Pawn's turn: ");
                    command = Console.ReadLine();
                    //this.ProcessPawnCommand(command);
                }
            }
        }

        private void ProcessKingCommand(string command)
        {

        }

        private bool CheckIfKingLost()
        {
            return true;
        }

        private bool CheckIfKingWon()
        {
            if (this.Board.King.PositionY == GameConstants.PawnsStartPositionY)
            {
                return true;
            }

            for (int i = 1; i < this.Board.Field.GetLength(1); i += 2)
            {
                if (this.Board.Field[this.Board.Field.GetLength(0) - 1, i] == (int)BoardSymbols.Available)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

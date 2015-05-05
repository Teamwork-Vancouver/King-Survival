namespace KingSurvival
{
    using System;
    using Models;
    using Commands;
    using Contracts;

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
            string command;
            MoveCommand moveCommand;
            CommandParser parser;

            while (CheckIfKingWon() || CheckIfKingLost())
            {
                this.Board.PrintBoard();

                if (this.Turns%2 == 0)
                {
                    Console.Write("King's turn: ");
                }
                else
                {
                    Console.Write("Pawns' turn: ");
                }
                
                try
                {
                    command = Console.ReadLine();
                    parser = new CommandParser(command, this.Board, this.Turns);
                    FigureEntry entry = parser.Parse();
                    MoveCommand commandObject =
                        CommandFactory.Create(entry.HorizontalDirection, entry.VerticalDirection, entry.Figure, Board, entry.Position);
                    commandObject.ProcessCommand();

                    this.Turns++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private bool CheckIfKingLost()
        {
            return true;
        }

        private bool CheckIfKingWon()
        {
            //if (this.Board.King.PositionY == GameConstants.PawnsStartPositionY)
            //{
            //    return true;
            //}

            //for (int i = 1; i < this.Board.Field.GetLength(1); i += 2)
            //{
            //    if (this.Board.Field[this.Board.Field.GetLength(0) - 1, i] == (int)BoardSymbols.Available)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }
    }
}

using System;
using System.Linq;
using KingSurvival.Commands;
using KingSurvival.Models;

namespace KingSurvival
{
    public class Game
    {
        public Game(Board board)
        {
            Board = board;
            Turns = 0;
        }

        public int Turns { get; set; }
        public Board Board { get; set; }

        public void Run()
        {
            string command;
            MoveCommand moveCommand;
            CommandParser parser;

            while (!CheckIfKingWon() || CheckIfKingLost())
            {
                Board.PrintBoard();

                if (Turns%2 == 0)
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
                    parser = new CommandParser(command, Board, Turns);
                    var entry = parser.Parse();
                    var commandObject =
                        CommandFactory.Create(entry.HorizontalDirection, entry.VerticalDirection, entry.Figure, Board,
                            entry.Position);
                    commandObject.ProcessCommand();

                    Turns++;
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
            bool isKingOnFirstRow =
                Board.Figures.FirstOrDefault(
                    x => x.Value.Symbol == GameConstants.KingSymbol && x.Key.Y == 0).Value != null;

            if (isKingOnFirstRow)
            {
                Console.WriteLine("The King is on the first row");
                return true;
            }

            for (var i = 0; i < GameConstants.PawnSymbols.Length; i++)
            {
                char currentSymbol = GameConstants.PawnSymbols[i];
                bool isCurrentPawnOnLastRow =
                    Board.Figures.FirstOrDefault(x => x.Value.Symbol == currentSymbol).Key.Y == GameConstants.BoardHeight;

                if (!isCurrentPawnOnLastRow)
                {
                    return false;
                }
            }

            Console.WriteLine("All pawns are or the last row");
            return true;
        }
    }
}
﻿namespace KingSurvival
{
    using System;
    using System.Linq;
    using Commands;
    using Enumerations;
    using Models;

    public class Game
    {
        public Game(Board board)
        {
            Board = board;
            Turns = 1;
        }

        public int Turns { get; set; }

        public Board Board { get; set; }

        public bool Running { get; set; }

        public void Run()
        {
            this.Running = true;

            string command;
            MoveCommand moveCommand;
            CommandParser parser;
            FigureEntry figureEntry;

            Board.PrintBoard();

            while (this.Running)
            {
                try
                {
                    Console.Write(Turns % 2 == 1 ? "King's turn: " : "Pawns' turn: ");

                    command = Console.ReadLine();
                    parser = new CommandParser(command, Board, Turns);
                    figureEntry = parser.Parse();
                    moveCommand =
                        CommandFactory.Create(figureEntry.HorizontalDirection, figureEntry.VerticalDirection, figureEntry.Figure,
                            figureEntry.Position, this.Board);
                    moveCommand.ProcessCommand();

                    Turns++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Board.PrintBoard();
                this.CheckForWinner();
            }
        }

        private bool CheckIfKingLost()
        {
            Position kingPosition = this.Board.Figures.FirstOrDefault(x => x.Value.Symbol == (char)FigureSymbols.King).Key;

            for (int i = 0; i < GameConstants.PossibleFigureMoves.GetLength(0); i++)
            {
                bool canMove =
                    this.Board.IsNextPositionAvailable(
                    kingPosition.X + GameConstants.PossibleFigureMoves[i, 0],
                    kingPosition.Y + GameConstants.PossibleFigureMoves[i, 1]);

                if (canMove)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckIfKingWon()
        {
            bool isKingOnFirstRow =
                Board.Figures.FirstOrDefault(
                    x => x.Value.Symbol == (char)FigureSymbols.King && x.Key.Y == 0).Value != null;

            if (isKingOnFirstRow)
            {
                return true;
            }

            var pawnPositions = this.Board.Figures.Where(f => f.Value.Symbol != (char)FigureSymbols.King).ToArray();

            for (int pawnIndex = 0; pawnIndex < this.Board.Figures.Keys.Count - 1; pawnIndex++)
            {
                int currentPawnNextLeftXPosition = pawnPositions[pawnIndex].Key.X +
                                                  GameConstants.PossibleFigureMoves[2, 0];
                int currentPawnNextLeftYPosition = pawnPositions[pawnIndex].Key.Y +
                                                   GameConstants.PossibleFigureMoves[2, 1];

                int currentPawnNextRightXPosition = pawnPositions[pawnIndex].Key.X +
                                                    GameConstants.PossibleFigureMoves[3, 0];
                int currentPawnNextRightYPosition = pawnPositions[pawnIndex].Key.Y +
                                                    GameConstants.PossibleFigureMoves[3, 1];

                bool canMove = this.Board.IsNextPositionAvailable(currentPawnNextLeftXPosition, currentPawnNextLeftYPosition)
                    || this.Board.IsNextPositionAvailable(currentPawnNextRightXPosition, currentPawnNextRightYPosition);

                if (canMove)
                {
                    return false;
                }
            }
            return true;
        }

        private void CheckForWinner()
        {
            if (this.CheckIfKingLost())
            {
                this.Running = false;
                Console.WriteLine(GameConstants.KingLoss, this.Turns / GameConstants.MovesPerTurn);
            }

            if (this.CheckIfKingWon())
            {
                this.Running = false;
                Console.WriteLine(GameConstants.KingVictory, this.Turns / GameConstants.MovesPerTurn);
            }
        }
    }
}
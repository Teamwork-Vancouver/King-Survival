namespace KingSurvival
{
    using System;
    using System.Linq;
    using Commands;
    using Enumerations;
    using Models;

    public class Game
    {
        private static volatile Game instance;
        private static readonly object syncRoot = new Object();

        private Game(Board board, Renderer renderer)
        {
            this.Renderer = renderer;
            this.Board = board;
            this.Turns = 1;
        }

        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            var board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
                            var renderer = new Renderer();
                            instance = new Game(board, renderer);
                        }
                    }
                }

                return instance;
            }
        }

        public Renderer Renderer { get; set; }

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

            this.Renderer.Render(this.Board);

            while (this.Running)
            {
                try
                {
                    Console.Write(this.Turns % 2 == 1 ? GameConstants.KingsTurnMessage : GameConstants.PawnsTurnMessage);

                    command = Console.ReadLine();
                    parser = new CommandParser(command, this.Board, this.Turns);
                    figureEntry = parser.Parse();
                    moveCommand =
                        CommandFactory.Create(
                        figureEntry.HorizontalDirection,
                        figureEntry.VerticalDirection,
                        figureEntry.Figure,
                        figureEntry.Position,
                        this.Board);
                    moveCommand.ProcessCommand();

                    this.Turns++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                this.Renderer.Render(this.Board);
                this.StopGameIfWinnerFound();
            }
        }
        /// <summary>
        /// Makes the necessary checks to return if the king lost the game
        /// </summary>
        /// <returns>Boolean</returns>
        private bool CheckIfKingLost()
        {
            Position kingPosition = this.Board.Figures.FirstOrDefault(x => x.Value.Symbol == (char)FigureSymbols.King).Key;

            for (int i = 0; i < GameConstants.PossibleFigureMoves.GetLength(0); i++)
            {
                bool canMove =
                    this.Board.IsPositionAvailableForMove(
                    kingPosition.X + GameConstants.PossibleFigureMoves[i, 0],
                    kingPosition.Y + GameConstants.PossibleFigureMoves[i, 1]);

                if (canMove)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Makes the necessary check to if the king lost the game
        /// </summary>
        /// <returns>Boolean</returns>
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

                bool canMove = this.Board.IsPositionAvailableForMove(currentPawnNextLeftXPosition, currentPawnNextLeftYPosition)
                    || this.Board.IsPositionAvailableForMove(currentPawnNextRightXPosition, currentPawnNextRightYPosition);

                if (canMove)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Combines if the king lost or won and stops the game loop.
        /// </summary>
        private void StopGameIfWinnerFound()
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
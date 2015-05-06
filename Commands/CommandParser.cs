namespace KingSurvival.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enumerations;
    using Models;

    public class CommandParser
    {
        public CommandParser(string commandText, Board board, int turns)
        {
            this.CommandText = commandText.ToUpper();
            this.Board = board;
            this.Turns = turns;
        }

        public int Turns { get; set; }

        public Board Board { get; set; }

        private string CommandText { get; set; }

        public FigureEntry Parse()
        {
            char figureSymbol = this.CommandText[0];

            if (this.Turns % 2 == 1 && figureSymbol == (char)FigureSymbols.King)
            {
                return this.GetFigureEntry(figureSymbol);
            }
            else if (this.Turns % 2 == 0 && GameConstants.PawnSymbols.Contains(figureSymbol))
            {
                return this.GetFigureEntry(figureSymbol);
            }
            else
            {
                throw new Exception();
            }
        }

        private int GetHorizontalDirection()
        {
            char commandHorizontalDirection = this.CommandText[2];

            switch (commandHorizontalDirection)
            {
                case (char)Directions.Right:
                    return 1;
                case (char)Directions.Left:
                    return -1;
                default: throw new Exception();
            }
        }

        private int GetVerticalDirection()
        {
            char commandVerticalDirection = this.CommandText[1];

            switch (commandVerticalDirection)
            {
                case (char)Directions.Down:
                    return 1;
                case (char)Directions.Up:
                    return -1;
                default: throw new Exception();
            }
        }

        private bool ValidateCommandLength(string commandText)
        {
            if (commandText.Length != 3)
            {
                return false;
            }

            return true;
        }

        private FigureEntry GetFigureEntry(char figureSymbol)
        {
            KeyValuePair<Position, IFigure> entry;
            entry = this.Board.Figures.FirstOrDefault(x => x.Value.Symbol == figureSymbol);
            return new FigureEntry(this.GetHorizontalDirection(), this.GetVerticalDirection(), entry.Value, entry.Key);
        }
    }
}

using System.Collections.Generic;
using KingSurvival.Contracts;

namespace KingSurvival.Commands
{
    using System;
    using System.Linq;
    using Models;

    public class CommandParser
    {
        private string commandText;

        public CommandParser(string commandText, Board board, int turns)
        {
            this.CommandText = commandText.ToUpper();
            this.Board = board;
            this.Turns = turns;
        }

        public int Turns { get; set; }

        public Board Board { get; set; }

        private string CommandText { get; set; }

        private int GetHorizontalDirection()
        {
            char commandHorizontalDirection = this.CommandText[2];

            switch (commandHorizontalDirection)
            {
                case 'R':
                    return 1;
                case 'L':
                    return -1;
                default: throw new Exception();
            }
        }

        private int GetVerticalDirection()
        {
            char commandVerticalDirection = this.CommandText[1];

            switch (commandVerticalDirection)
            {
                case 'D':
                    return 1;
                case 'U':
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

        public FigureEntry Parse()
        {
            char figureSymbol = this.CommandText[0];

            if (this.Turns % 2 == 0 && figureSymbol == 'K')
            {
                return GetFigureEntry(figureSymbol);
            }
            else if (this.Turns % 2 == 1 && GameConstants.PawnSymbols.Contains(figureSymbol))
            {
                return GetFigureEntry(figureSymbol);
            }
            else
            {
                throw new Exception();
            }
        }

        private FigureEntry GetFigureEntry(char figureSymbol)
        {
            KeyValuePair<Position, IFigure> entry;
            entry = this.Board.Figures.FirstOrDefault(x => x.Value.Symbol == figureSymbol);
            return new FigureEntry(this.GetHorizontalDirection(), this.GetVerticalDirection(), entry.Value, entry.Key);
        }
    }
}

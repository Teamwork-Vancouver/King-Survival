﻿namespace KingSurvival.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enumerations;
    using Exceptions;
    using Models;

    /// <summary>
    /// The class which parses an input command.
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// The constructor of the Parser class.
        /// </summary>
        /// <param name="commandText">The text given as a command.</param>
        /// <param name="board">The board on which the command should be executed.</param>
        /// <param name="turns">The count of turns all figures took.</param>
        public CommandParser(string commandText, Board board, int turns)
        {
            this.CommandText = commandText.ToUpper();
            this.Board = board;
            this.Turns = turns;
        }

        public int Turns { get; set; }

        public Board Board { get; set; }

        private string CommandText { get; set; }

        /// <summary>
        /// Parses the command text an checks if it is valid.
        /// </summary>
        /// <returns>returns FigureEntry</returns>
        public FigureEntry Parse()
        {
            if (!this.ValidateCommandLength())
            {
                throw new InvalidCommandException(ExceptionMessages.InvalidCommandLenght);
            }

            char figureSymbol = this.CommandText[0];

            if (this.Turns % 2 == 1 && figureSymbol == (char)FigureSymbols.King)
            {
                return this.GetFigureEntry(figureSymbol);
            }
            
            if (this.Turns % 2 == 0 && GameConstants.PawnSymbols.Contains(figureSymbol))
            {
                return this.GetFigureEntry(figureSymbol);
            }

            throw new InvalidCommandException(ExceptionMessages.InvalidFigureCharacter);
        }

        /// <summary>
        /// Gets the second symbol of the command text and returns a negative/positive integer number.
        /// </summary>
        /// <returns>(Integer) horisontal direction</returns>
        private int GetHorizontalDirection()
        {
            char commandHorizontalDirection = this.CommandText[2];

            switch (commandHorizontalDirection)
            {
                case (char)Directions.Right:
                    return 1;
                case (char)Directions.Left:
                    return -1;
                default: throw new InvalidCommandException(ExceptionMessages.InvalidHorizontalDirection);
            }
        }

        /// <summary>
        /// Gets the third symbol of the ommand text and parses it.
        /// </summary>
        /// <returns>(Integer) vertical direction</returns>
        private int GetVerticalDirection()
        {
            char commandVerticalDirection = this.CommandText[1];

            switch (commandVerticalDirection)
            {
                case (char)Directions.Down:
                    return 1;
                case (char)Directions.Up:
                    return -1;
                default: throw new InvalidCommandException(ExceptionMessages.InvalidVerticalDirection);
            }
        }

        /// <summary>
        /// Checks if the command text is exatly three letters.
        /// </summary>
        /// <returns>Boolean</returns>
        private bool ValidateCommandLength()
        {
            if (this.CommandText.Length != GameConstants.MaxCommandWordLength)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Searches the board for the figure symbol passed to it and makes a FigureEntry Object.
        /// </summary>
        /// <param name="figureSymbol">The symbol of the current fugure.</param>
        /// <returns>The FigureEntry object.</returns>
        private FigureEntry GetFigureEntry(char figureSymbol)
        {
            KeyValuePair<Position, IFigure> entry;
            entry = this.Board.Figures.FirstOrDefault(x => x.Value.Symbol == figureSymbol);
            return new FigureEntry(this.GetHorizontalDirection(), this.GetVerticalDirection(), entry.Value, entry.Key);
        }
    }
}

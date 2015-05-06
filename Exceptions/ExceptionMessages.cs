namespace KingSurvival.Exceptions
{
    public class ExceptionMessages
    {
        public const string InvalidCommandLenght = "Command lenght must be 3 characters long.";
        public const string InvalidHorizontalDirection = "Wrong horizontal direction.";
        public const string InvalidVerticalDirection = "Wrong vertical direction.";
        public const string InvalidFigureCharacter = "Wrong figure character.";
        public const string InvalidUpMove = "The figure you chose to move cannot move up.";
        public const string UnavailablePosition = "Occupied position to move.";
        public const string OutOfBounds = "Figure cannot move out of the board.";
        public const string InvalidFactoryCommand = "Invalid command vertical direction given.";
    }
}

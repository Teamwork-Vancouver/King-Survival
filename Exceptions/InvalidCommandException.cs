namespace KingSurvival.Exceptions
{
    public class InvalidCommandException : MoveCommandException
    {
        public InvalidCommandException(string message)
            : base(message)
        {
        }
    }
}

namespace KingSurvival.Exceptions
{
    public class CommandException : GameException
    {
        public CommandException(string message) 
            : base(message)
        {
        }
    }
}

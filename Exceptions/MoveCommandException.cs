namespace KingSurvival.Exceptions
{
    using System;

    public class MoveCommandException : CommandException
    {
        public MoveCommandException(string message)
            : base(message)
        {

        }
    }
}

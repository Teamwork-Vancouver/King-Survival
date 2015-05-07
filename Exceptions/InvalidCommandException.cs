namespace KingSurvival.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidCommandException : MoveCommandException
    {
        /// <summary>
        /// Invalid Command Exeption.
        /// Trown when the user command is invalid.
        /// </summary>
        public InvalidCommandException(string message)
            : base(message)
        {
        }
    }
}

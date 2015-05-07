namespace KingSurvival.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CommandException : GameException
    {
        /// <summary>
        /// Command Exeption
        /// This Exception is thrown when the user enters wrong command.
        /// </summary>
        public CommandException(string message)
            : base(message)
        {
        }
    }
}

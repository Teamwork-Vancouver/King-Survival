namespace KingSurvival.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MoveCommandException : CommandException
    {
        /// <summary>
        /// Move Command Exeption.
        /// Thrown when there is invalid command to move an object.
        /// </summary>
        public MoveCommandException(string message)
            : base(message)
        {
        }
    }
}

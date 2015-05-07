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
        public InvalidCommandException()
            : base()
        {
        }
 
        public InvalidCommandException(string message)
            : base(message)
        {
        }
 
        public InvalidCommandException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
 
        public InvalidCommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
 
        public InvalidCommandException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

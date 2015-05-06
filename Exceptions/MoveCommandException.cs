namespace KingSurvival.Exceptions
{
    using System;
    using System.Runtime.Serialization;


    public class MoveCommandException : CommandException
    {
       
        /// <summary>
        /// Move Command Exeption
        /// Thrown when there is invalid command to move an object
        /// </summary>
        public MoveCommandException()
            : base()
        {
        }
 
        public MoveCommandException(string message)
            : base(message)
        {
        }
 
        public MoveCommandException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
 
        public MoveCommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
 
        public MoveCommandException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected MoveCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

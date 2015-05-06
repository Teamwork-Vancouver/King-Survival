using System;
using System.Runtime.Serialization;
namespace KingSurvival.Exceptions
{
    public class CommandException : GameException
    {
         /// <summary>
        /// Command Exeption
        /// This Exception is thrown when the user enters wrong command.
        /// </summary>
        public CommandException()
            : base()
        {
        }
 
        public CommandException(string message)
            : base(message)
        {
        }
 
        public CommandException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
 
        public CommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
 
        public CommandException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }
 
        protected CommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

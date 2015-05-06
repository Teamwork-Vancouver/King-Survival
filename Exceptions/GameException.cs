﻿namespace KingSurvival.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class GameException : Exception
    {
        /// <summary>
        /// 
        /// 
        /// </summary>
       
        public GameException()
            : base()
        {
        }
 
        public GameException(string message)
            : base(message)
        {
        }
 
        public GameException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }
 
        public GameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
 
        public GameException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected GameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

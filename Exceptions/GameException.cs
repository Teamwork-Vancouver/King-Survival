namespace KingSurvival.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class GameException : ApplicationException
    {
        /// <summary>
        /// The base game exception.
        /// </summary>
        public GameException(string message)
            : base(message)
        {
        }
    }
}

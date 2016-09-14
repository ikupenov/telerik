namespace Exceptions_Homework.Exceptions
{
    using System;

    public class InvalidScoreException : Exception
    {
        public InvalidScoreException()
        {
        }

        public InvalidScoreException(string message) : base(message)
        {
        }

        public InvalidScoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
namespace StudentClass.Infrastructure.Verification.Exception
{
    using System;

    public class InvalidSSNException : ApplicationException
    {
        public InvalidSSNException(string message) : base(message) { }

        public InvalidSSNException(string message, Exception innerException) : base(message, innerException) { }
    }
}

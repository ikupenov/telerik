namespace StudentClass.Infrastructure.Verification.Exception
{
    using System;

    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException(string message) : base(message) { }

        public InvalidNameException(string message, Exception innerException) : base(message, innerException) { }
    }
}

namespace StudentClass.Infrastructure.Verification.Exception
{
    using System;

    public class InvalidEmailAddressException : ApplicationException
    {
        public InvalidEmailAddressException(string message) : base(message) { }

        public InvalidEmailAddressException(string message, Exception innerException) : base(message, innerException) { }
    }
}

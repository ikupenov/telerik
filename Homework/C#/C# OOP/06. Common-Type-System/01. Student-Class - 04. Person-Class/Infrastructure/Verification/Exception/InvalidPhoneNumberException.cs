namespace StudentClass.Infrastructure.Verification.Exception
{
    using System;

    public class InvalidPhoneNumberException : ApplicationException
    {
        public InvalidPhoneNumberException(string message) : base(message) { }

        public InvalidPhoneNumberException(string message, Exception innerException) : base(message, innerException) { }
    }
}

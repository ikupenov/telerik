namespace BankAccounts.Infrastructure.Verification.Exceptions
{
    using System;

    public class NegativeNumberOfMonthsException : ApplicationException
    {
        public NegativeNumberOfMonthsException(string msg) : base(msg) { }

        public NegativeNumberOfMonthsException(string msg, Exception innerException) : base (msg, innerException) { }
    }
}

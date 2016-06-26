namespace BankAccounts.Infrastructure.Verification
{
    using BankAccounts.Infrastructure.Verification.Exceptions;
    using System;

    public static class NegativeVerification
    {
        public static void VerifyMonth(int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberOfMonthsException("Months cannot be less than zero");
            }
        }

        public static void VerifyDeposit(decimal moneyToDeposit)
        {
            if (moneyToDeposit <= 0)
            {
                throw new ArgumentException("Deposit cannot be equal or less than zero");
            }
        }

        public static void VerifyWithdraw(decimal moneyToWithdraw)
        {
            if (moneyToWithdraw <= 0)
            {
                throw new ArgumentException("Deposit cannot be equal or less than zero");
            }
        }
    }
}

namespace BankAccounts.Models.Accounts
{
    using BankAccounts.Models.Abstract;
    using Infrastructure.Constants;
    using Infrastructure.Contracts;
    using Infrastructure.Enumerations;
    using Infrastructure.Verification;
    using System;

    public class DepositAccount : Bank, IDepositable, IWithdrawable
    {
        private const decimal INDIVIDUAL_MIN_INTEREST_AMOUNT = 1000m;

        public DepositAccount(CustomerType customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate) { }

        public void Deposit(decimal moneyToDeposit)
        {
            NegativeVerification.VerifyDeposit(moneyToDeposit);
            base.Balance += moneyToDeposit;
        }

        public void Withdraw(decimal moneyToWithdraw)
        {
            NegativeVerification.VerifyWithdraw(moneyToWithdraw);
            base.Balance -= moneyToWithdraw;
        }

        public override decimal InterestAmount(int numberOfMonths)
        {
            NegativeVerification.VerifyMonth(numberOfMonths);

            if (base.Balance < INDIVIDUAL_MIN_INTEREST_AMOUNT)
            {
                return GlobalConstants.ZERO_INTEREST_AMOUNT;
            }
            else
            {
                return ((base.InterestRate / 100) * base.Balance) * numberOfMonths;
            }
        }
    }
}

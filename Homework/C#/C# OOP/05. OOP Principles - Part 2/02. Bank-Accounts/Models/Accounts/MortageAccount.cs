namespace BankAccounts.Models.Accounts
{
    using BankAccounts.Infrastructure.Contracts;
    using BankAccounts.Infrastructure.Enumerations;
    using BankAccounts.Models.Abstract;
    using Infrastructure.Constants;
    using Infrastructure.Verification;
    using System;

    public class MortageAccount : Bank, IDepositable
    {
        private const double INITIAL_COMPANY_INTEREST = 0.5;
        private const int INDIVIDUAL_MONTHS_WITHOUT_INTEREST = 6;

        public MortageAccount(CustomerType customer, decimal balance, double interestRate) : base(customer, balance, interestRate) { }

        public void Deposit(decimal moneyToDeposit)
        {
            NegativeVerification.VerifyDeposit(moneyToDeposit);
            base.Balance += moneyToDeposit;
        }

        public override decimal InterestAmount(int numberOfMonths)
        {
            NegativeVerification.VerifyMonth(numberOfMonths);

            if (base.Customer == CustomerType.Company)
            {
                return (decimal)(numberOfMonths * INITIAL_COMPANY_INTEREST);
            }
            else if (base.Customer == CustomerType.Individual && numberOfMonths <= INDIVIDUAL_MONTHS_WITHOUT_INTEREST)
            {
                return GlobalConstants.ZERO_INTEREST_AMOUNT;
            }
            else
            {
                return (decimal)(base.InterestRate * numberOfMonths);
            }
        }
    }
}

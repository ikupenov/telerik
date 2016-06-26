namespace BankAccounts.Models.Accounts
{
    using BankAccounts.Infrastructure.Contracts;
    using BankAccounts.Infrastructure.Enumerations;
    using BankAccounts.Models.Abstract;
    using Infrastructure.Constants;
    using Infrastructure.Verification;
    using System;

    public class LoanAccount : Bank, IDepositable
    {
        private const int INDIVIDUAL_MONTHS_WITHOUT_INTEREST = 3;
        private const int COMPANY_MONTHS_WITHOUT_INTEREST = 2;

        public LoanAccount(CustomerType customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate) { }

        public void Deposit(decimal moneyToDeposit)
        {
            NegativeVerification.VerifyDeposit(moneyToDeposit);
            base.Balance += moneyToDeposit;
        }

        public override decimal InterestAmount(int numberOfMonths)
        {
            NegativeVerification.VerifyMonth(numberOfMonths);

            if (base.Customer == CustomerType.Individual && numberOfMonths > INDIVIDUAL_MONTHS_WITHOUT_INTEREST)
            {
                return ((base.InterestRate / GlobalConstants.MAX_PERCENT) * base.Balance) *
                            (numberOfMonths - INDIVIDUAL_MONTHS_WITHOUT_INTEREST);
            }
            else if (base.Customer == CustomerType.Company && numberOfMonths > COMPANY_MONTHS_WITHOUT_INTEREST)
            {
                return ((base.InterestRate / GlobalConstants.MAX_PERCENT) * base.Balance) * 
                            (numberOfMonths - COMPANY_MONTHS_WITHOUT_INTEREST);
            }
            else
            {
                return GlobalConstants.ZERO_INTEREST_AMOUNT;
            }
        }
    }
}

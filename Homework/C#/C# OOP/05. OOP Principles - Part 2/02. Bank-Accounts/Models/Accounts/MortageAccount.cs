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
        private const decimal INITIAL_COMPANY_INTEREST = 0.5m;
        private const int COMPANY_MONTHS_WITH_LIMITED_INTEREST = 12;
        private const int INDIVIDUAL_MONTHS_WITHOUT_INTEREST = 6;

        public MortageAccount(CustomerType customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate) { }

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
                return ((base.InterestRate / 100) * base.Balance) * (numberOfMonths - INDIVIDUAL_MONTHS_WITHOUT_INTEREST);
            }
            else if (base.Customer == CustomerType.Company && numberOfMonths <= COMPANY_MONTHS_WITH_LIMITED_INTEREST)
            {
                return ((INITIAL_COMPANY_INTEREST / 100) * base.Balance) * numberOfMonths;
            }
            else if (base.Customer == CustomerType.Company && numberOfMonths > COMPANY_MONTHS_WITH_LIMITED_INTEREST)
            {
                int monthsWithoutLimitedInterest = numberOfMonths - COMPANY_MONTHS_WITH_LIMITED_INTEREST;
                return (((INITIAL_COMPANY_INTEREST / 100) * base.Balance) * COMPANY_MONTHS_WITH_LIMITED_INTEREST) + 
                        (((base.InterestRate / 100) * base.Balance) * monthsWithoutLimitedInterest);
            }
            else
            {
                return GlobalConstants.ZERO_INTEREST_AMOUNT;
            }
        }
    }
}

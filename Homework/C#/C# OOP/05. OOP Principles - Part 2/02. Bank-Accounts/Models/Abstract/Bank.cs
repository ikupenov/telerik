namespace BankAccounts.Models.Abstract
{
    using BankAccounts.Infrastructure.Enumerations;
    using Infrastructure.Constants;
    using System;

    public abstract class Bank
    {
        private decimal balance;
        private double interestRate;

        public Bank(CustomerType customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public CustomerType Customer { get; }

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value < GlobalConstants.EMPTY_BANK_ACCOUNT)
                {
                    throw new ArgumentOutOfRangeException("Account balance cannot be negative");
                }

                this.balance = value;
            }
        }

        public double InterestRate
        {
            get { return this.interestRate; }
            private set
            {
                if (value < GlobalConstants.ZERO_INTEREST)
                {
                    throw new ArgumentOutOfRangeException("Interest rate cannot be negative");
                }

                this.interestRate = value;
            }
        }

        public virtual decimal InterestAmount(int numberOfMonths)
        {
            return (decimal)(this.InterestRate * numberOfMonths);
        }
    }
}

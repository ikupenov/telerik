namespace BankAccounts.Infrastructure.Contracts
{
    interface IDepositable
    {
        void Deposit(decimal moneyToDeposit);
    }
}

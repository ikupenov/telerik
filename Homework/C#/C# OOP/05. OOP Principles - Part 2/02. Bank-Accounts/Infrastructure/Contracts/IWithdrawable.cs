namespace BankAccounts.Infrastructure.Contracts
{
    interface IWithdrawable
    {
        void Withdraw(decimal moneyToWithdraw);
    }
}

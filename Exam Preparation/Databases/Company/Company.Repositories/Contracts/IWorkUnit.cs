using System;

namespace Company.Repositories.Contracts
{
    public interface IWorkUnit : IDisposable
    {
        void Commit();
    }
}
using System;

namespace ToyStore.Repository.Contracts
{
    public interface IWorkUnit : IDisposable
    {
        void Save();
    }
}
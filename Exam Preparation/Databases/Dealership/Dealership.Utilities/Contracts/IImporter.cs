namespace Dealership.Utilities.Contracts
{
    public interface IImporter
    {
        int Order { get; }

        void Import();
    }
}
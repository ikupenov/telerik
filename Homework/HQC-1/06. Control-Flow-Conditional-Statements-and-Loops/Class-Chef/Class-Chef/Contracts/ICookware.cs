namespace ClassChef.Contracts
{
    public interface ICookware
    {
        int Capacity { get; }

        void Add(IVegetable vegetable);
    }
}
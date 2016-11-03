namespace Company.Utilities.Contracts
{
    public interface INumberGenerator
    {
        int GetRandomInteger(int minNumber, int maxNumber);

        double GetRandomDouble(double minNumber, double maxNumber);
    }
}
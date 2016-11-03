namespace Company.Utilities.Contracts
{
    public interface IStringGenerator
    {
        string GetRandomString(int minLength, int maxLength);
    }
}
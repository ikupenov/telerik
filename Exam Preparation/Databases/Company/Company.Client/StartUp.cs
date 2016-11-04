using Company.Client.Configuration;
using Company.Client.Contracts;

using Ninject;

namespace Company.Client
{
    internal class StartUp
    {
        private static void Main()
        {
            IKernel kernel = new StandardKernel(new CompanyModule());

            IClient client = kernel.Get<IClient>();
            client.Start();
        }
    }
}
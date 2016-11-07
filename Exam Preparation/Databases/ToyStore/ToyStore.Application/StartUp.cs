using ToyStore.Utilities.Seeders;

namespace ToyStore.Application
{
    internal class StartUp
    {
        private static void Main()
        {
            Seeder.Seed();
        }
    }
}
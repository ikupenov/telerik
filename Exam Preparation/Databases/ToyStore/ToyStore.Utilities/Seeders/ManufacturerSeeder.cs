using ToyStore.Data;

namespace ToyStore.Utilities.Seeders
{
    internal class ManufacturerSeeder : Seeder
    {
        private const int ManufacturersCount = 50;

        protected override int Order => 1;

        public override void SeedDatabase()
        {
            for (int i = 0; i < ManufacturersCount; i++)
            {
                var manufacturer = new Manufacturer
                {
                    Name = this.StringGenerator.GetRandomString(3, 20),
                    Country = this.StringGenerator.GetRandomString(3, 20)
                };

                this.ManufacturersRepository.Add(manufacturer);
            }

            using (var unitOfWork = this.UnitOfWork())
            {
                unitOfWork.Save();
            }
        }
    }
}
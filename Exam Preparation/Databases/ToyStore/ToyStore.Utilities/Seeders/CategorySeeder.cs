using ToyStore.Data;

namespace ToyStore.Utilities.Seeders
{
    internal class CategorySeeder : Seeder
    {
        private const int CategoriesCount = 100;

        protected override int Order => 3;

        public override void SeedDatabase()
        {
            for (int i = 0; i < CategoriesCount; i++)
            {
                var category = new Category
                {
                    Name = this.StringGenerator.GetRandomString(3, 15),
                };

                this.CategoriesRepository.Add(category);
            }

            using (var unitOfWork = this.UnitOfWork())
            {
                unitOfWork.Save();
            }
        }
    }
}
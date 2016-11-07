using ToyStore.Data;

namespace ToyStore.Utilities.Seeders
{
    internal class AgeRangeSeeder : Seeder
    {
        private const int AgeRangesCount = 100;

        protected override int Order => 2;

        public override void SeedDatabase()
        {
            for (int i = 0; i < AgeRangesCount; i++)
            {
                var ageRange = new AgeRanx
                {
                    MinAge = this.NumberGenerator.GetRandomInteger(0, 7),
                    MaxAge = this.NumberGenerator.GetRandomInteger(8, 13)
                };

                this.AgeRangesRepository.Add(ageRange);
            }

            using (var unitOfWork = this.UnitOfWork())
            {
                unitOfWork.Save();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

using ToyStore.Data;

namespace ToyStore.Utilities.Seeders
{
    internal class ToySeeder : Seeder
    {
        private const int ToysCount = 200;

        protected override int Order => 4;

        public override void SeedDatabase()
        {
            var colors = new List<string>
            {
                "Red",
                "Blue",
                "Green",
                "Purple"
            };

            var types = new List<string>
            {
                "Puzzle",
                "Plush",
            };

            for (int i = 0; i < ToysCount; i++)
            {
                var toy = new Toy()
                {
                    Name = this.StringGenerator.GetRandomString(2, 20),
                    Color = colors[this.NumberGenerator.GetRandomInteger(0, colors.Count)],
                    Price = (decimal)Math.Round(this.NumberGenerator.GetRandomDouble(1.00, 340), 2),
                    Type = types[this.NumberGenerator.GetRandomInteger(0, types.Count)],

                    AgeRanx = this.AgeRangesRepository.Entities.ToList()
                        [this.NumberGenerator.GetRandomInteger(0, this.AgeRangesRepository.Count)],

                    Manufacturer = this.ManufacturersRepository.Entities.ToList()
                        [this.NumberGenerator.GetRandomInteger(0, this.ManufacturersRepository.Count)],

                    Categories = this.CategoriesRepository.Entities
                        .Skip(this.NumberGenerator.GetRandomInteger(0, this.CategoriesRepository.Count))
                        .Take(this.NumberGenerator.GetRandomInteger(1, 4))
                        .ToList()
                };

                this.ToysRepository.Add(toy);
            }

            using (var unitOfWork = this.UnitOfWork())
            {
                unitOfWork.Save();
            }
        }
    }
}
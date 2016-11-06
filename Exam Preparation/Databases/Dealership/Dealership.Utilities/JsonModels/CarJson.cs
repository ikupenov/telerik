using Dealership.Models;
using Newtonsoft.Json;

namespace Dealership.Utilities.JsonModels
{
    public class CarJson
    {
        public int Year { get; set; }

        [JsonProperty("ManufacturerName")]
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public DealerJson Dealer { get; set; }
    }
}
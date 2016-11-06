using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required, MaxLength(11)]
        public string Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [ForeignKey("Dealer")]
        public int DealerId { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }
    }
}

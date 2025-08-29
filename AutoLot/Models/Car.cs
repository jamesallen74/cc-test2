using System.ComponentModel.DataAnnotations;

namespace AutoLot.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Trim { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Engine { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public string Drivetrain { get; set; } = string.Empty;
        public string Features { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
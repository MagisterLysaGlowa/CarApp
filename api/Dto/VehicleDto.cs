using api.Models;

namespace api.Dto
{
    public class VehicleDto
    {
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Color { get; set; }
        public int GearboxID { get; set; }
        public double Mileage { get; set; }
        public int EngineID { get; set; }
        public int SeatingCapacity { get; set; }
        public string? BodyType { get; set; }
        public string? VIN { get; set; }
        public decimal Price { get; set; }
        public int VehicleTypeID { get; set; }
    }
}

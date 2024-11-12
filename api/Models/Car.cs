namespace api.Models
{
    public class Car
    {
        public int CarID { get; set; }                // Unique identifier for the car
        public string? Make { get; set; }             // Manufacturer (e.g., Ford, Toyota)
        public string? Model { get; set; }            // Model of the car (e.g., Mustang, Camry)
        public int Year { get; set; }                 // Year the car was manufactured
        public string? Color { get; set; }            // Color of the car
        public string? Transmission { get; set; }     // Transmission type (e.g., Automatic, Manual)
        public double Mileage { get; set; }           // Mileage in kilometers or miles
        public string? FuelType { get; set; }         // Fuel type (e.g., Gasoline, Diesel, Electric)
        public double EngineCapacity { get; set; }    // Engine capacity in liters (e.g., 2.0L)
        public int Horsepower { get; set; }           // Horsepower of the car
        public int SeatingCapacity { get; set; }      // Number of seats
        public string? BodyType { get; set; }         // Body type (e.g., Sedan, SUV, Truck)
        public string? VIN { get; set; }              // Vehicle Identification Number (unique identifier)
        public string? LicensePlate { get; set; }     // License plate number
        public bool IsAvailable { get; set; }         // Availability status (e.g., available for sale or rent)
        public decimal Price { get; set; }            // Price of the car (e.g., for sale or rent)
    }
}

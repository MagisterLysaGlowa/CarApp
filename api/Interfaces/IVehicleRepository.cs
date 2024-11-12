using api.Models;

namespace api.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> Update(Vehicle vehicle,int vehicleID);
        Task<Vehicle> Create(Vehicle vehicle);
        Task<Vehicle> Get(int vehicleID);
        Task<int> Delete(int vehicleID);
        Task<List<Vehicle>> GetAll();
    }
}

using api.Models;

namespace api.Interfaces
{
    public interface IVehicleTypeRepository
    {
        Task<VehicleType> Update(VehicleType vehicleType, int vehicleTypeID);
        Task<VehicleType> Create(VehicleType vehicleType);
        Task<VehicleType> Get(int vehicleTypeID);
        Task<int> Delete(int vehicleTypeID);
        Task<List<VehicleType>> GetAll();
    }
}

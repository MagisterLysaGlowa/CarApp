using api.Models;

namespace api.Interfaces
{
    public interface IFuelTypeRepository
    {
        Task<FuelType> Update(FuelType fuelType, int fuelTypeID);
        Task<FuelType> Create(FuelType fuelType);
        Task<FuelType> Get(int fuelTypeID);
        Task<int> Delete(int fuelTypeID);
        Task<List<FuelType>> GetAll();
    }
}

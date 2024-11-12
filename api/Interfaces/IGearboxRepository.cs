using api.Models;

namespace api.Interfaces
{
    public interface IGearboxRepository
    {
        Task<Gearbox> Update(Gearbox gearbox, int gearboxID);
        Task<Gearbox> Create(Gearbox gearbox);
        Task<Gearbox> Get(int gearboxID);
        Task<int> Delete(int gearboxID);
        Task<List<Gearbox>> GetAll();
    }
}

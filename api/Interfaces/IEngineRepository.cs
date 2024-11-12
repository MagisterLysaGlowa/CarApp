using api.Models;

namespace api.Interfaces
{
    public interface IEngineRepository
    {
        Task<Engine> Update(Engine engine, int engineID);
        Task<Engine> Create(Engine engine);
        Task<Engine> Get(int engineID);
        Task<int> Delete(int engineID);
        Task<List<Engine>> GetAll();
    }
}

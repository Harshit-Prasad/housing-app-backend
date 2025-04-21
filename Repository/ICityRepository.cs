using server.Models;

namespace server.Repository
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        void AddCity(City city);
        void DeleteCity(int id);
        Task<bool> SaveAsync();
    }
}

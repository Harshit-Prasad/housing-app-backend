using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _dataContext;
        public CityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public DataContext DataContext { get; }

        public void AddCity(City city)
        {
            _dataContext.AddAsync(city);
        }

        public void DeleteCity(int id)
        {
            var city = _dataContext.Cities.Find(id);
            _dataContext.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _dataContext.Cities.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}

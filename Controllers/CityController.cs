using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repository;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ICityRepository _cityRepository;
        public CityController(
            DataContext datacontext,
            ICityRepository cityRepository
            ) 
        {
            this._dataContext = datacontext;
            this._cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCitites()
        {
            var cities = await _cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(City city)
        {
            _cityRepository.AddCity(city);
            await _cityRepository.SaveAsync();

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            _cityRepository.DeleteCity(id);
            await _cityRepository.SaveAsync();
            return Ok(id);
        }

    }
}

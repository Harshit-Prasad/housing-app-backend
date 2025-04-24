using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCitites()
        {
            var cities = await _unitOfWork.CityRepository.GetCitiesAsync();

            var citiesDto = _mapper.Map<IEnumerable<CityDTO>>( cities );

            return Ok(citiesDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityDTO cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            
            _unitOfWork.CityRepository.AddCity(city);
            await _unitOfWork.SaveAsync();

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            _unitOfWork.CityRepository.DeleteCity(id);
            await _unitOfWork.SaveAsync();
            return Ok(id);
        }

    }
}

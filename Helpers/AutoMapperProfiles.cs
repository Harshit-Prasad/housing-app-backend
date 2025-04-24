using AutoMapper;
using server.DTOs;
using server.Models;

namespace server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}

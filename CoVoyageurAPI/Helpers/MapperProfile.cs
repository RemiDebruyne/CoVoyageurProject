using AutoMapper;
using CoVoyageurCore.Models;
using CoVoyageurCore.DTOs;

namespace CoVoyageurAPI.Helpers
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<User, LoginRequestDTO>().ReverseMap();
        }
    }
}

using AutoMapper;
using Papara.Core.Entites;
using Papara.DataAccess.DTOs;

namespace Papara.DataAccess.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

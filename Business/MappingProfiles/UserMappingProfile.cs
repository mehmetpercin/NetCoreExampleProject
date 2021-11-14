using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
        }
    }
}

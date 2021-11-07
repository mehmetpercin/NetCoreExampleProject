using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}

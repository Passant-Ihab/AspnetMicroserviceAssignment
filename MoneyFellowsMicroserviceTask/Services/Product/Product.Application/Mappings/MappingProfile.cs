using AutoMapper;
using Products.Application.Features.Queries.GetProductsList;
using Products.Core.Entities;

namespace Products.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductsDTO>().ReverseMap();
        }
    }
}

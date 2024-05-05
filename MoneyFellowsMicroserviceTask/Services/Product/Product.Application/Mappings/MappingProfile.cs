using AutoMapper;
using Products.Application.Features.Commands.AddProduct;
using Products.Application.Features.Commands.UpdateProduct;
using Products.Application.Features.Queries.GetProduct;
using Products.Application.Features.Queries.GetProductsList;
using Products.Core.Entities;

namespace Products.Application.Mappings
{
    /// <summary>
    /// Mapper profile to configure the models mappings
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductsDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, AddProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}

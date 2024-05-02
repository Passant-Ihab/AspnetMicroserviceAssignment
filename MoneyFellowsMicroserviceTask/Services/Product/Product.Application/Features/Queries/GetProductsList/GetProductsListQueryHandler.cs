using AutoMapper;
using MediatR;
using Products.Application.Contracts.Infrastructure;

namespace Products.Application.Features.Queries.GetProductsList
{
    public class GetProductsListQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductsListQuery, List<ProductsDTO>>
    {

        private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<List<ProductsDTO>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetByBrandNameAsync(request.BrandName);
            return _mapper.Map<List<ProductsDTO>>(productList);
        }
    }
}

using AutoMapper;
using MediatR;
using Products.Application.Contracts.Infrastructure;
using Products.Application.Features.Queries.GetProductsList;
using Products.Core.Entities;

namespace Products.Application.Features.Commands.AddProduct
{
    public class AddProductCommandQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
           var order = await  _productRepository.AddAsync(productEntity);

            return order.Id;
        }
    }
}

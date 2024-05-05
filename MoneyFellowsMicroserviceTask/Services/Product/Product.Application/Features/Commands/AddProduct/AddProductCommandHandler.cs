using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Contracts.Infrastructure;
using Products.Application.Features.Queries.GetProductsList;
using Products.Core.Entities;

namespace Products.Application.Features.Commands.AddProduct
{
    public class AddProductCommandQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<AddProductCommandQueryHandler> logger) : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly ILogger<AddProductCommandQueryHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
           var product = await  _productRepository.AddAsync(productEntity);

            _logger.LogInformation($"Product {product.Id} is successfully created.");

            return product.Id;
        }
    }
}

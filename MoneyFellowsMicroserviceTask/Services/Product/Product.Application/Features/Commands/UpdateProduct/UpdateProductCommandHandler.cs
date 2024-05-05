using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Contracts.Infrastructure;
using Products.Application.Exceptions;
using Products.Application.Features.Commands.DeleteProduct;
using Products.Core.Entities;

namespace Products.Application.Features.Commands.UpdateProduct
{
    /// <inheritdoc />
    public class UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper,ILogger<UpdateProductCommandHandler> logger ) : IRequestHandler<UpdateProductCommand>
    {

        private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly ILogger<UpdateProductCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <inheritdoc />
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                _logger.LogError($"Product {request.Id} is not found.");

                throw new EntityNotFoundException(nameof(product), request.Id);
            }

            _mapper.Map(request, product, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(product);

            _logger.LogInformation($"Product {product.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}

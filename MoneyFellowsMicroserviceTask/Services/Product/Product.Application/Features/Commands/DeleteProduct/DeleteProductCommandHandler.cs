using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Contracts.Infrastructure;
using Products.Application.Exceptions;

namespace Products.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<DeleteProductCommandHandler> logger) : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly ILogger<DeleteProductCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                _logger.LogError($"Product {request.Id} is not found.");

                throw new EntityNotFoundException(nameof(product), request.Id);
            }
            await _productRepository.DeleteAsync(request.Id);

            _logger.LogInformation($"Product {product.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}

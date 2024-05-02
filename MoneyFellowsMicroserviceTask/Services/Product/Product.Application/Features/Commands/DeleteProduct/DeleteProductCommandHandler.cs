using AutoMapper;
using MediatR;
using Products.Application.Contracts.Infrastructure;
using Products.Application.Exceptions;

namespace Products.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new EntityNotFoundException(nameof(product), request.Id);
            }
            await _productRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}

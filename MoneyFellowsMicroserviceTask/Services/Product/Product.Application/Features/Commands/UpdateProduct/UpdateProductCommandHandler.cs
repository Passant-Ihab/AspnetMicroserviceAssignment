using AutoMapper;
using MediatR;
using Products.Application.Contracts.Infrastructure;
using Products.Core.Entities;

namespace Products.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<UpdateProductCommand>
    {

        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                //throw new NotFoundException(nameof(product), request.Id);
            }

            _mapper.Map(request, product, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}

using MediatR;

namespace Products.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }

    }
}

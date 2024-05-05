using MediatR;
using Products.Core.Entities;

namespace Products.Application.Features.Queries.GetProduct
{
    public class GetProductByIdQuery (int id) : IRequest<ProductDTO>
    {
        public int Id { get; set; } = id;
    }
}

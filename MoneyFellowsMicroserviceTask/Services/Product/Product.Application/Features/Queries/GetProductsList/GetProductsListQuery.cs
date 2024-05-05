using MediatR;

namespace Products.Application.Features.Queries.GetProductsList
{
    /// <inheritdoc />
    public class GetProductsListQuery : IRequest<List<ProductsDTO>>
    {

    }
}

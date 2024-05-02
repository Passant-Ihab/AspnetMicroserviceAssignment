using MediatR;

namespace Products.Application.Features.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<List<ProductsDTO>>
    {

    }
}

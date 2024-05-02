using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Features.Queries.GetProductsList;
using System.Net;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{brandName}", Name = "GetProduct")]
        [ProducesResponseType(typeof(IEnumerable<ProductsDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetProductsByBrandName(string brandName)
        {
            var query = new GetProductsListByBrandNameQuery(brandName);
            var products = await _mediator.Send(query);
            return Ok(products);
        }
    }
}

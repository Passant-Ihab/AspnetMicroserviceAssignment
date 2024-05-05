using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Products.Application.Features.Commands.AddProduct;
using Products.Application.Features.Commands.DeleteProduct;
using Products.Application.Features.Commands.UpdateProduct;
using Products.Application.Features.Queries.GetProduct;
using Products.Application.Features.Queries.GetProductsList;
using System.Net;

namespace Products.API.Controllers
{
    [EnableRateLimiting("sliding")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController(IMediator mediator, ILogger<ProductController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        private readonly ILogger<ProductController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet("{brandName}", Name = "GetProductsByBrandName")]
        [ProducesResponseType(typeof(IEnumerable<ProductsDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetProductsByBrandName(string brandName)
        {
            var query = new GetProductsListByBrandNameQuery(brandName);
            var products = await _mediator.Send(query);
            return Ok(products);
        }


        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var query = new GetProductByIdQuery(id);
            var products = await _mediator.Send(query);
            return Ok(products);
        }


        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] AddProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

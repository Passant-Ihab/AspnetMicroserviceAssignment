using MediatR;

namespace Products.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }
    }
}

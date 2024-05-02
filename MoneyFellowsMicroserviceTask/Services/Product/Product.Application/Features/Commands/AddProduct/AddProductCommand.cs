using MediatR;

namespace Products.Application.Features.Commands.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }
    }
}

namespace Products.Application.Features.Queries.GetProductsList
{
    public class ProductsDTO
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

using Products.Core.Entities;

namespace Products.Infrastructure.Persistence
{
    public class ProductContextSeed
    {
        public static async Task SeedAsync(ProductContext context)
        {
            if(!context.Products.Any())
            {
                context.Products.AddRange(GetProducts());
                await context.SaveChangesAsync();
            }
        }


        private static IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new() { BrandName = "Nike", Description = "White Shoes", Owner = "Nike Store", Name = "Nike shoes", Price = 3547, Rating = 4 },
                new() { BrandName = "Puma", Description = "Black T-Shirt", Owner = "Puma Store", Name = "Puma T-shirt", Price = 2235, Rating = 3 }
            };
        }
    }
}

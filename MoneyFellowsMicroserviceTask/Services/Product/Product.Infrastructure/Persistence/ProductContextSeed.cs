using Microsoft.Extensions.Logging;
using Products.Core.Entities;

namespace Products.Infrastructure.Persistence
{
    public class ProductContextSeed
    {
        public static async Task SeedAsync(ProductContext context, ILogger<ProductContextSeed> logger)
        {
            if(!context.Products.Any())
            {
                context.Products.AddRange(GetProducts());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ProductContext).Name);
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

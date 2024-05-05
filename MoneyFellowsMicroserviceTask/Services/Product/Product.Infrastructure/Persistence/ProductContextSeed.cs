using Microsoft.Extensions.Logging;
using Products.Core.Entities;

namespace Products.Infrastructure.Persistence
{
    /// <summary>
    /// Seeding class to fill some data for the first run of the DB
    /// </summary>
    public class ProductContextSeed
    {
        /// <summary>
        /// Inserts some initial data to the DB
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static async Task SeedAsync(ProductContext context, ILogger<ProductContextSeed> logger)
        {
            if(!context.Products.Any())
            {
                context.Products.AddRange(GetProducts());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ProductContext).Name);
            }
        }

        /// <summary>
        /// Returns some fixed products data for the new database
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Product> GetProducts()
        {
            return
            [
                new() {  BrandName = "Nike", Description = "White Shoes", Owner = "Nike Store", Name = "Nike shoes", Price = 3547, Rating = 4, CreatedBy= "passant", CreatedDate = DateTime.Now, LastModifiedBy = "Passant", LastModifiedDate = DateTime.Now},
                new() { BrandName = "Puma", Description = "Black T-Shirt", Owner = "Puma Store", Name = "Puma T-shirt", Price = 2235, Rating = 3, CreatedBy= "passant", CreatedDate = DateTime.Now, LastModifiedBy = "Passant", LastModifiedDate = DateTime.Now }
            ];
        }
    }
}

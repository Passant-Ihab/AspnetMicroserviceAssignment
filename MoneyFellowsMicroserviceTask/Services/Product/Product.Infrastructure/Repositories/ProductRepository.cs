using Microsoft.EntityFrameworkCore;
using Products.Application.Contracts.Infrastructure;
using Products.Core.Entities;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class ProductRepository(ProductContext context) : RepositoryBase<Product>(context), IProductRepository
    {
        /// <inheritdoc />
        public async Task<IEnumerable<Product>> GetByBrandNameAsync(string brandName)
        {
            return await _context.Products.Where(p => p.BrandName == brandName).ToListAsync();
        }
    }
}

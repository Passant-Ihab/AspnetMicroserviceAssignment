using Products.Core.Entities;
namespace Products.Application.Contracts.Infrastructure
{
    /// <summary>
    /// Product repository contract 
    /// </summary>
    public interface IProductRepository : IAsyncRepository<Product>
    {
        /// <summary>
        /// Gets the list of products by the brand name
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetByBrandNameAsync(string brandName);
    }
}

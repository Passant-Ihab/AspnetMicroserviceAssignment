using Products.Core.Common;
using System.Linq.Expressions;

namespace Products.Application.Contracts.Infrastructure
{
    /// <summary>
    /// Base repository contract
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Gets Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Gets an entity by the search criteria 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsunc(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsunc(int id);
    }
}

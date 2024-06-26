﻿using Microsoft.EntityFrameworkCore;
using Products.Application.Contracts.Infrastructure;
using Products.Core.Common;
using Products.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Products.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class RepositoryBase<T>(ProductContext context) : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly ProductContext _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <inheritdoc />
        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException();
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

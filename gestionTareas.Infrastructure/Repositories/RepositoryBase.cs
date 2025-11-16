using gestionTareas.Application.Contracts.Persistence;
using gestionTareas.Domain.Models.Common;
using gestionTareas.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

   

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> GetAsyncByField(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .Where(predicate)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

      
        public async Task<IReadOnlyList<T>> GetAsyncWithIncludes(
            Expression<Func<T, bool>>? predicate = null,
            List<string>? includeStrings = null)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            if (includeStrings != null)
            {
                foreach (var include in includeStrings)
                {
                    query = query.Include(include);
                }
            }

            if (predicate != null)
                query = query.Where(predicate);

            return await query.AsNoTracking().ToListAsync();
        }
    }
}

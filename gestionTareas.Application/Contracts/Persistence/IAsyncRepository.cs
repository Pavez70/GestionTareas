using gestionTareas.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<T> AddAsync(T entity);
        void AddEntity(T entity);
        void AddRange(List<T> entities);

        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetAsyncByField(Expression<Func<T, bool>> predicate);

        Task<T> UpdateAsync(T entity);
        void UpdateEntity(T entity);

        Task DeleteAsync(T entity);
        void DeleteEntity(T entity);

        // Includes dinámicos
        Task<IReadOnlyList<T>> GetAsyncWithIncludes(
            Expression<Func<T, bool>>? predicate = null,
            List<string>? includeStrings = null);
    }
}

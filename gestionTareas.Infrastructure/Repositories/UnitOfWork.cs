using gestionTareas.Application.Contracts.Persistence;
using gestionTareas.Domain.Models.Common;
using gestionTareas.Infrastructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Hashtable? _repositories;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repoType = typeof(RepositoryBase<>);
                var repoInstance = Activator.CreateInstance(
                    repoType.MakeGenericType(typeof(TEntity)),
                    _context
                );

                _repositories.Add(type, repoInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

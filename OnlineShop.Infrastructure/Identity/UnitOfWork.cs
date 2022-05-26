using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Domain;
using OnlineShop.Infrastructure.Persistance.Contexts;
using OnlineShop.Infrastructure.Persistance.Repositories;
using System;
using System.Collections;
using System.Threading.Tasks;


namespace OnlineShop.Infrastructure.Identity
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopDbContext _context;
        private Hashtable _repositories;
        public UnitOfWork(OnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EFCoreRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
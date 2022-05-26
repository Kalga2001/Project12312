using OnlineShop.Domain;
using System;
using System.Threading.Tasks;


namespace OnlineShop.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();

    }
}
using OnlineShop.Domain;
using OnlineShop.Application.Common.Models;
using System.Linq.Expressions;

namespace OnlineShop.Application.Common.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec);
        Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec);
        Task<int> CountAsync(ISpecification<TEntity> spec);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity
                                                                                             where TDto : class;
        Task<IReadOnlyList<Order>> ListAsync(OrderWithItemsAndOrderingSpecipication spec);
    }
}

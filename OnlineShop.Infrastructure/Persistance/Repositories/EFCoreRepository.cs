using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Application.Common.Models;
using OnlineShop.Application.Extensions;
using OnlineShop.Domain;
using OnlineShop.Infrastructure.Persistance.Contexts;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OnlineShop.Infrastructure.Persistance.Repositories
{
    public class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly OnlineShopDbContext _context;

        public EFCoreRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public Task<PaginatedResult<TDto>> GetPagedData<TEntity1, TDto>(PagedRequest pagedRequest)
            where TEntity1 : BaseEntity
            where TDto : class
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> ListAsync(OrderWithItemsAndOrderingSpecipication spec)
        {
            throw new NotImplementedException();
        }
    }
}

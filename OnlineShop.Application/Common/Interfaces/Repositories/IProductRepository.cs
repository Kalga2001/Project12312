using OnlineShop.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OnlineShop.Application.Common.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
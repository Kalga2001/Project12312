using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace OnlineShop.Application.Common.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string id);


    }
}

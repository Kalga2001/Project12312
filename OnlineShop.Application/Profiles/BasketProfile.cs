using AutoMapper;
using OnlineShop.Domain;
using OnlineShop.Application.App.Baskets.Responses;

namespace OnlineShop.Application.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketItem, BasketListDto>();
        }
    }
}

using OnlineShop.Application.App.Products.Commands;
using OnlineShop.Application.App.Products.Responses;
using AutoMapper;
using OnlineShop.Domain;

namespace OnlineShop.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>()
                .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.ProductType.Name));
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.ProductType.Name));

            CreateMap<CreateProductCommand, Product>();

            CreateMap<UpdateProductCommand, Product>();
        }
    }
}

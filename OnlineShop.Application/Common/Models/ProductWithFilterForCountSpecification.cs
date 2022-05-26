using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace OnlineShop.Application.Common.Models
{
    public class ProductWithFilterForCountSpecification : BaseSpecipication<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
        {

        }
    }
}

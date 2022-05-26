using AutoMapper;
using MediatR;
using OnlineShop.Domain;
using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Application.App.Products.Responses;

namespace OnlineShop.Application.App.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly EFCoreRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(EFCoreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdWithInclude<Product>(request.ProductId, product=>product.ProductTypeId);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}

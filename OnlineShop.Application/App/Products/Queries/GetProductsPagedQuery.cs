using MediatR;
using OnlineShop.Domain;
using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Application.Common.Models;
using OnlineShop.Application.App.Products.Responses;

namespace OnlineShop.Application.App.Products.Queries
{
    public class GetProductsPagedQuery : IRequest<PaginatedResult<ProductListDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }

    public class GetBooksPagedQueryHandler : IRequestHandler<GetProductsPagedQuery, PaginatedResult<ProductListDto>>
    {
        private readonly EFCoreRepository _repository;

        public GetBooksPagedQueryHandler(EFCoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<ProductListDto>> Handle(GetProductsPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedProductsDto = await _repository.GetPagedData<Product, ProductListDto>(request.PagedRequest);
            return pagedProductsDto;
        }
    }
}

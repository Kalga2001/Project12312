using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.App.Products.Queries;
using OnlineShop.Application.App.Products.Commands;
using OnlineShop.Application.Common.Models;
using OnlineShop.Domain;
using OnlineShop.Application.App.Products.Responses;

namespace OnlineShop.API.Controllers
{
    [Route("api/products")]
    public class ProductsController : AppBaseController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<ProductListDto>> GetPagedProducts(PagedRequest pagedRequest)
        {
            var response = await _mediator.Send(new GetProductsPagedQuery() { PagedRequest = pagedRequest });
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            var productDto = await _mediator.Send(new GetProductByIdQuery() { ProductId = id });
            return productDto;
        }

        [HttpPost]
        public async Task<ProductDto> CreateBook(CreateProductCommand productForUpdateDto)
        {
            var productDto = await _mediator.Send(productForUpdateDto);
            return productDto;
        }

        [HttpPut("{id}")]
        public async Task UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand() { Id = id });
        }
    }
}

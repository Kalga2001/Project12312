using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.App.Baskets.Queries;
using OnlineShop.Application.App.Baskets.Responses;

namespace OnlineShop.API.Controllers
{
    [Route("api/baskets")]
    public class BasketController : AppBaseController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<BasketListDto>> GetAllPublishers()
        {
            var baskets = await _mediator.Send(new GetAllBasketsQuery());
            return baskets;
        }
    }
}

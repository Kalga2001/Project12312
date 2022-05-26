using AutoMapper;
using MediatR;
using OnlineShop.Domain;
using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Application.App.Baskets.Responses;

namespace OnlineShop.Application.App.Baskets.Queries
{
    public class GetAllBasketsQuery : IRequest<IEnumerable<BasketListDto>>
    {

    }

    public class GetAllPublishersQueryHandler : IRequestHandler<GetAllBasketsQuery, IEnumerable<BasketListDto>>
    {
        private readonly EFCoreRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPublishersQueryHandler(EFCoreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasketListDto>> Handle(GetAllBasketsQuery request, CancellationToken cancellationToken)
        {
            var basketList = await _repository.GetAll<BasketItem>();
            var basketDtoList = _mapper.Map<List<BasketListDto>>(basketList);
            return basketDtoList;
        }
    }
}

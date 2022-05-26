using AutoMapper;
using MediatR;
using OnlineShop.Domain;
using OnlineShop.Application.Common.Interfaces.Repositories;

namespace OnlineShop.Application.App.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly EFCoreRepository _repository;

        public UpdateBookCommandHandler(IMapper mapper, EFCoreRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById<Product>(request.ProductTypeId);
            _mapper.Map(request, product);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

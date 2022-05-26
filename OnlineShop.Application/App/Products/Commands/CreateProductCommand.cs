using AutoMapper;
using MediatR;
using OnlineShop.Application.App.Products.Responses;
using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Domain;

namespace OnlineShop.Application.App.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
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

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly EFCoreRepository _repository;

        public CreateProductCommandHandler(IMapper mapper, EFCoreRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            _repository.Add(product);
            await _repository.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
    }
}

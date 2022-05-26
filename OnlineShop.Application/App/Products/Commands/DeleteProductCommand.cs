using MediatR;
using OnlineShop.Domain;
using OnlineShop.Application.Common.Interfaces.Repositories;

namespace OnlineShop.Application.App.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly EFCoreRepository _repository;

        public DeleteBookCommandHandler(EFCoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete<Product>(request.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

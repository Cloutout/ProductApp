using MediatR;
using ProductApp.Application.Common;
using ProductApp.Application.Products.Inputs;
using ProductApp.Domain.Aggregates.Product;

namespace ProductApp.Application.Products.Commands
{
    public class CreateProductCommand : IRequest
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommand(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductCommandInput request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price, request.Stock);
            await _repository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id; // normalde kullanıcıya crate işleminde değer döndürmememiz gerekiyor.
        }
    }
}

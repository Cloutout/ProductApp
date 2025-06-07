using MediatR;
using ProductApp.Application.Common;
using ProductApp.Application.Products.Inputs;
using ProductApp.Domain.Aggregates.Product;

namespace ProductApp.Application.Products.Commands;

public class CreateProductCommand : IRequest
{
    public CreateProductCommandInput Input { get; }

    private CreateProductCommand(CreateProductCommandInput input)
    {
        Input = input;
    }

    public static CreateProductCommand Create(CreateProductCommandInput input)
    {
        return new CreateProductCommand(input);
    }
}

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IProductRepository productRepository;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        this.unitOfWork = unitOfWork;
        this.productRepository = productRepository;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Domain validation ProductCreateModel içinde yapılacak
        var productCreateModel = new ProductCreateModel
        {
            Name = request.Input.Name,
            Price = request.Input.Price,
            Stock = request.Input.Stock
        };

        var product = Product.Create(productCreateModel);

        await productRepository.CreateAsync(product, cancellationToken).ConfigureAwait(false);
        await unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
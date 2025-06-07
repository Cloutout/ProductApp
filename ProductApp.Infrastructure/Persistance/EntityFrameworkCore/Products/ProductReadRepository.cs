using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Common;
using ProductApp.Application.Products.Models;

namespace ProductApp.Infrastructure.Persistance.EntityFrameworkCore.Products;

public sealed class ProductReadRepository : IProductReadRepository
{
    private readonly ProductDbContext context;

    public ProductReadRepository(ProductDbContext context)
    {
        this.context = context;
    }

    public async Task<GetProductsByFiltersResponseModel> GetProductsByFilters(GetProductByFilterRequestModel requestModel, CancellationToken cancellationToken)
    {
        var products = await context.Products
            .Skip((requestModel.PageNumber - 1) * requestModel.PageSize)
            .Take(requestModel.PageSize)
            .ToListAsync(cancellationToken);

        return new GetProductsByFiltersResponseModel
        {
            Products = products,
            PageNumber = requestModel.PageNumber,
            PageSize = requestModel.PageSize
        };
    }
}
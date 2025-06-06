using ProductApp.Application.Products.Models;

namespace ProductApp.Application.Common
{
    public interface IProductReadRepository
    {
        Task<GetProductsByFiltersResponseModel> GetProductsByFilters(GetProductByFilterRequestModel requestModel, CancellationToken cancellationToken);
    }
}
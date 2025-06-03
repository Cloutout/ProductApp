using ProductApp.Domain.Aggregates.Product;

namespace ProductApp.Application.Common
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<List<Product>> GetPagedAsync(int pageNumber, int pageSize);
    }
}

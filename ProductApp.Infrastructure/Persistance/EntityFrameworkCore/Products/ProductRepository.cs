using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Common;
using ProductApp.Application.Products.Models;
using ProductApp.Domain.Aggregates.Product;
using ProductApp.Infrastructure.Persistance.EntityFrameworkCore;

namespace ProductApp.Infrastructure.Persistance.EntityFrameworkCore.Products
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext context;

        public ProductRepository(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await context.Products.AddAsync(product, cancellationToken);
        }

        public async Task<List<Product>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await context.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
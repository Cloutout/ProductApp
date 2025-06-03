using Microsoft.EntityFrameworkCore;
using ProductApp.Application;
using ProductApp.Domain.Aggregates.Product;
using ProductApp.Infrastructure.Persistance.EntityFrameworkCore.Products.EntityConfigurations;

namespace ProductApp.Infrastructure.Persistance.EntityFrameworkCore
{
    public class ProductDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public async Task<bool> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.Domain.Aggregates.Product;

namespace ProductApp.Infrastructure.Persistance.EntityFrameworkCore.Products.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.OwnsOne(p => p.Price, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("Price")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasColumnName("Currency")
                    .HasMaxLength(3)
                    .IsRequired();
            });

            builder.Property(p => p.StockQuantity)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .HasDatabaseName("IX_Products_Name");
        }
    }
}

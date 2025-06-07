using ProductApp.Domain.Aggregates.Product.ValueObject;
using ProductApp.Domain.Base;

namespace ProductApp.Domain.Aggregates.Product;

public sealed class Product : IAggregateRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public Money Price { get; private set; }
    public int Stock { get; private set; }

    private Product() { } // EF Core için

    public Product(string name, Money price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ürün ismi boş olamaz");

        if (stock < 0)
            throw new ArgumentException("Stok 0'dan küçük olamaz");

        Name = name;
        Price = price;
        Stock = stock;
    }

    public static Product Create(ProductCreateModel model)
    {
        var price = new Money(model.Price);
        return new Product(model.Name, price, model.Stock);
    }
}

public sealed class ProductCreateModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
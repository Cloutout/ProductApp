using ProductApp.Domain.Aggregates.Product.ValueObject;
using ProductApp.Domain.Base;

namespace ProductApp.Domain.Aggregates.Product;

public sealed class Product : IAggregateRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public Money Price { get; private set; }
    public int Stock { get; private set; }

    private Product() { } // EF Core için boş constroctor

    public Product(string name, Money price, int stock)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Ürün ismi boş olamaz");

        if (name.Length > 100)
            throw new ArgumentException("ürün ismi 100 karakterden fazla olamaz");

        Name = name;
        Price = price;
        Stock = stock;
    }

    public static Product Create(ProductCreateModel model)
    {
        return new Product(model.Name, model.Price, model.Stock);
    }
    
}

public sealed class ProductCreateModel
{
    public string Name { get; set; }
    public Money Price { get; set; }
    public int Stock { get; set; }
}
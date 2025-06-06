namespace ProductApp.Application.Products.Inputs;

public record CreateProductCommandInput
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
}
using ProductApp.Domain.Aggregates.Product.ValueObject;

namespace ProductApp.Application.Products.Inputs
{
    public record CreateProductCommandInput
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Stock Stock  { get; set; }
    }
}

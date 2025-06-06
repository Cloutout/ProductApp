namespace ProductApp.Application.Products.Outputs;

public class GetProductsQueryOutput
{
    public List<ProductOutput> Products { get; set; } = new();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
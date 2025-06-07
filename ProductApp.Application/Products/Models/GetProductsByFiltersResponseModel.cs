using ProductApp.Application.Common;
using ProductApp.Domain.Aggregates.Product;

namespace ProductApp.Application.Products.Models;

public class GetProductsByFiltersResponseModel
{
    public List<Product> Products { get; set; } = new();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
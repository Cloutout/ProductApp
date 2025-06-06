using ProductApp.Application.Products.Inputs;
using ProductApp.Application.Products.Models;
using ProductApp.Application.Products.Outputs;

namespace ProductApp.Application.Products.Mappers;

public class ProductMapper
{
    public GetProductByFilterRequestModel MapToGetProductByFilterRequestModel(GetProductsQueryInput input)
    {
        return new GetProductByFilterRequestModel
        {
            PageNumber = input.PageNumber,
            PageSize = input.PageSize
        };
    }

    public GetProductsQueryOutput MapToGetProductsQueryOutput(GetProductsByFiltersResponseModel responseModel)
    {
        var productOutputs = responseModel.Products.Select(x => new ProductOutput
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price.Amount,
            Stock = x.Stock
        }).ToList();

        return new GetProductsQueryOutput
        {
            Products = productOutputs,
            PageNumber = responseModel.PageNumber,
            PageSize = responseModel.PageSize
        };
    }
}
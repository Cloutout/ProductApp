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
            
            Page = input.PageNumber,
            PageSize = input.PageSize
        };
    }

    public GetProductsQueryOutput MapToGetProductsQueryOutput(GetProductsByFiltersResponseModel responseModel)
    {
        var productOutputs = responseModel.Products.Select(x => new ProductOutput
        {
            Id = x.Id,
            Name = x.Name,
            Price = (long)x.Price.Amount,
            Stock = x.Stock

        }).ToList();

        var totalPages = (int)Math.Ceiling((double)responseModel.TotalCount / responseModel.PageSize);

        return new GetProductsQueryOutput
        {
            Products = productOutputs,
            PageNumber = responseModel.PageNumber,
            PageSize = responseModel.PageSize,
            
        };
    }
}
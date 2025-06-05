using MediatR;
using ProductApp.Api.Models.Requests;
using ProductApp.Application.Products.Commands;
using ProductApp.Application.Products.Queries;

namespace ProductApp.Api.EndpointMappings
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/products").WithTags("Products");

            group.MapPost("", async (CreateProductRequest request, IMediator mediator) =>
                {
                    try
                    {
                        var command = new CreateProductCommand(request.Name, request.Price, request.Stock);
                        var productId = await mediator.Send(command);
                        return Results.Created($"/api/products/{productId}", new { Id = productId });
                    }
                    catch (ArgumentException ex)
                    {
                        return Results.BadRequest(new { Error = ex.Message });
                    }
                })
                .WithName("CreateProduct")
                .WithSummary("Create a new product");

            group.MapGet("", async (int pageNumber = 1, int pageSize = 25, IMediator mediator = null) =>
                {
                    var query = new GetProductsQuery(pageNumber, pageSize);
                    var result = await mediator.Send(query);
                    return Results.Ok(result);
                })
                .WithName("GetProducts")
                .WithSummary("Get products with pagination");
        }
    }
}
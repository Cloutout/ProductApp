using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Api.EndpointMappings;
using ProductApp.Api.Models.Requests;
using ProductApp.Api.Models.Response;
using ProductApp.Application.Products.Commands;
using ProductApp.Application.Products.Queries;

namespace ProductApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var commandInput = ProductEndpointMappings.ToCreateCommandInput(request);
        var command = CreateProductCommand.Create(commandInput);

        await mediator.Send(command, cancellationToken);

        return Ok(new CreateProductResponse { Message = "Ürün başarıyla oluşturuldu" });
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request, CancellationToken cancellationToken)
    {
        var queryInput = ProductEndpointMappings.ToGetQueryInput(request);
        var query = GetProductsQuery.Create(queryInput);

        var result = await mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Api.EndpointMappings;
using ProductApp.Api.Models.Requests;
using ProductApp.Api.Models.Response;
using ProductApp.Application.Products.Commands;
using ProductApp.Application.Products.Outputs;
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

    [HttpPost("CreateProduct")]
    [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commandInput = ProductEndpointMappings.ToCreateCommandInput(request);
            var command = CreateProductCommand.Create(commandInput);

            await mediator.Send(command, cancellationToken);

            return Ok(new CreateProductResponse { Message = "Ürün başarıyla oluşturuldu" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpGet("GetProductList")]
    [ProducesResponseType(typeof(GetProductsQueryOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductList([FromQuery] GetProductsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var queryInput = ProductEndpointMappings.ToGetQueryInput(request);
            var query = GetProductsQuery.Create(queryInput);

            var result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = "Bir hata oluştu", Details = ex.Message });
        }
    }
}
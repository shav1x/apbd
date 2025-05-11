using Microsoft.AspNetCore.Mvc;
using tut8.Contracts.Requests;
using tut8.Contracts.Responses;
using tut8.Services.Abstractions;

namespace tut8.Controllers;

[ApiController]
[Route("api/productwarehouse")]
public class WarehouseController : ControllerBase
{
    private readonly IProductWarehouseService _productWarehouseService;

    public WarehouseController(IProductWarehouseService productWarehouseService)
    {
        _productWarehouseService = productWarehouseService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<GetAllProductWarehouseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllProductWarehouseAsync(CancellationToken cancellationToken = default)
    {
        var productWarehouses = await _productWarehouseService.GetAllProductWarehouseAsync(cancellationToken);

        if (productWarehouses is null || !productWarehouses.Any())
        {
            return NotFound();
        }

        return Ok(productWarehouses);
    }


    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddProductToWarehouseAsync(
        [FromBody] AddProductToWarehouseRequest request,
        CancellationToken cancellationToken)
    {
        var createdId = await _productWarehouseService.CreateProductWarehouseAsync(request, cancellationToken);
        
        return Created(string.Empty, createdId);
    }
}
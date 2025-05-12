using Microsoft.AspNetCore.Mvc;
using tut8.Contracts.Requests;
using tut8.Contracts.Responses;
using tut8.Exceptions;
using tut8.Services.Abstractions;

namespace tut8.Controllers;

[ApiController]
[Route("api/productwarehouse")]
public class WarehouseController : ControllerBase
{
    private readonly IProductWarehouseService _productWarehouseService;
    private readonly ILogger<WarehouseController> _logger;

    public WarehouseController(IProductWarehouseService productWarehouseService, ILogger<WarehouseController> logger)
    {
        _productWarehouseService = productWarehouseService;
        _logger = logger;
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
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddProductToWarehouseAsync(
        [FromBody] AddProductToWarehouseRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            // Call service layer logic
            var createdId = await _productWarehouseService.CreateProductWarehouseAsync(request, cancellationToken);
            return Created(string.Empty, createdId); // Status 201
        }
        catch (ProductInOrderException ex)
        {
            _logger.LogWarning(ex, "The product is already added to an order. Request: {Request}", request);
            return Conflict(new { Message = "The product is already included in an order." }); // Status 409 Conflict
        }
        catch (CreatedAtException ex)
        {
            _logger.LogWarning(ex, "The request's created-at date is invalid for the given order. Request: {Request}", request);
            return BadRequest(new { Message = "The request date is invalid. Ensure it is later than the order's creation date." }); // Status 400
        }
        catch (OrderWasCompletedException ex)
        {
            _logger.LogWarning(ex, "The order has already been completed. Request: {Request}", request);
            return Conflict(new { Message = "The order has already been completed." }); // Status 409 Conflict
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding product to warehouse. Request: {Request}", request);
            return StatusCode(500, "An internal server error occurred."); // Status 500
        }
    }

}
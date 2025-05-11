using tut8.Contracts.Requests;
using tut8.Contracts.Responses;
using tut8.Entities;
using tut8.Exceptions;
using tut8.Infrastructure.Repositories.Abstractions;
using tut8.Mappers;
using tut8.Services.Abstractions;

namespace tut8.Services;

public class ProductWarehouseService : IProductWarehouseService
{
    private readonly IProductWarehouseRepository _productWarehouseRepository;
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IOrderRepository _orderRepository;

    public ProductWarehouseService(
        IProductWarehouseRepository productWarehouseRepository,
        IProductRepository productRepository,
        IWarehouseRepository warehouseRepository,
        IOrderRepository orderRepository)
    {
        _productWarehouseRepository = productWarehouseRepository;
        _productRepository = productRepository;
        _warehouseRepository = warehouseRepository;
        _orderRepository = orderRepository;
    }


    public async Task<int> CreateProductWarehouseAsync(AddProductToWarehouseRequest productWarehouseRequest,
        CancellationToken cancellationToken)
    {
        var productExists = await _productRepository.ProductExistsAsync(productWarehouseRequest.ProductId, cancellationToken);
        
        var warehouseExists = await _warehouseRepository.WarehouseExistsAsync(productWarehouseRequest.WarehouseId, cancellationToken);
        
        if (!productExists)
        {
            throw new ProductDoesNotExistException(productWarehouseRequest.ProductId);
        }
        
        if (!warehouseExists)
        {
            throw new WarehouseDoesNotExistException(productWarehouseRequest.WarehouseId);
        }

        var orderExists = await _orderRepository.GetOrderIdAsync(productWarehouseRequest.ProductId, productWarehouseRequest.Amount,
            productWarehouseRequest.CreatedAt, cancellationToken);

        if (orderExists == -1)
        {
            throw new ProductInOrderException(productWarehouseRequest.ProductId);
        }
        
        var orderCompleted = await _orderRepository.OrderWasCompletedAsync(productWarehouseRequest.ProductId, cancellationToken);
        
        if (orderCompleted)
        {
            throw new OrderWasCompletedException();
        }

        var updated = await _orderRepository.UpdateOrderFulfilledAtAsync(productWarehouseRequest.ProductId);

        if (!updated)
        {
            throw new Exception("Order was not updated");
        }
        
        var newProductWarehouse = new ProductWarehouse
        {
            Product = new Product { Id = productWarehouseRequest.ProductId },
            Warehouse = new Warehouse { Id = productWarehouseRequest.WarehouseId },
            Amount = productWarehouseRequest.Amount,
            Price = new Product { Id = productWarehouseRequest.ProductId }.Price * productWarehouseRequest.Amount,
            CreatedAt = DateTime.Now
        };
        
        var generatedId = await _productWarehouseRepository.CreateProductWarehouseAsync(newProductWarehouse, cancellationToken);
        
        return generatedId;
        
    }
    
    public async Task<ICollection<GetAllProductWarehouseResponse>> GetAllProductWarehouseAsync(CancellationToken cancellationToken)
    {
        // Fetch product warehouse data from the repository
        var productWarehouses = await _productWarehouseRepository.GetProductWarehousesAsync(cancellationToken);

        // If no data is found, return an empty list
        if (productWarehouses is null || !productWarehouses.Any())
        {
            return new List<GetAllProductWarehouseResponse>();
        }

        // Map the entity data to the response model using the mapper
        return productWarehouses.MapToGetAllProductWarehouseResponse();
    }
    
}

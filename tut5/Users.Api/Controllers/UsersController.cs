using Microsoft.AspNetCore.Mvc;
using Users.Api.Contracts.Requests;
using Users.Api.Data;
using Users.Api.Models;

namespace Users.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly List<User> _users = UsersRepository.Users;
    private readonly List<Order> _orders = OrdersRepository.Orders;

    #region CRUD

    // Get all users (GET api/users)
    [HttpGet]
    public IActionResult GetAll([FromQuery] string orderBy = "name_asc")
    {
        // 200 OK response
        return Ok(_users);
    }

    // Get specific user by id (GET api/users/{id})
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            // Error 404
            return NotFound();
        }
        return Ok(user);
    }

    // Create a new user
    [HttpPost]
    public IActionResult Create(CreateUserRequest request)
    {
        var id = _users.Max(u => u.Id) + 1;
        var newUser = new User { Id = id, FullName = request.FullName, Email = request.Email };
        _users.Add(newUser);
        return CreatedAtAction(nameof(Get), new { id = id }, newUser);
    }

    // Update existing user
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateUserRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound();
        user.FullName = request.FullName;
        user.Email = request.Email;
        return Ok(user);
    }

    // Delete provided user
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound();
        _users.Remove(user);
        return NoContent(); // <-- Also can be Ok(), but better to use NoContent()
    }

    #endregion

    #region CRUD - Subresource

    // Get all orders for the provided user
    [HttpGet("{userId:}/orders")]
    public IActionResult GetAllUserOrders(int userId)
    {
        var orders = _orders.Where(x => x.UserId == userId).ToList();
        return Ok(orders);
    }

    // Get specific order for the provided user
    [HttpGet("{userId:int}/orders/{orderId:int}")]
    public IActionResult GetAllUserOrders(int userId, int orderId)
    {
        var order = _orders.FirstOrDefault(x => x.UserId == userId && x.Id == orderId);
        if (order is null)
            return NotFound();
        return Ok(order);
    }

    #endregion
}

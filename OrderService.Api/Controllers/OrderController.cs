using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Entities;
using OrderService.Core.Interfaces.Order;

namespace OrderService.Api.Controllers;


[ApiController]
[Route("api/[controller]")]

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(int id)
    {
        var order = await _orderService.GetById(id);

        if (order is null)
            return NotFound("No order found with the given id");

        return Ok(order);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
    {
        var allOrders = await _orderService.GetAll();
        if (allOrders is null)
            return NotFound("No orders found");

        return Ok(allOrders);
    }

    [HttpPost]
    public async Task<ActionResult> AddOrder(Order order)
    {
        if (order is null)
            return BadRequest("Failed to add order");

        await _orderService.Add(order);
        return Ok("New order added successfully");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrder(Order order)
    {
        if (order is null)
            return BadRequest("Failed to update given order");

        await _orderService.Update(order);
        return Ok("Order updated successfully");

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        await _orderService.Delete(id);
        return Ok("Order deleted successfully");

    }



}
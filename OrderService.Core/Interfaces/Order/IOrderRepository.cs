using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Order;

public interface IOrderRepository : IRepository<Order>
{
	Task UpdateOrderStatus(int id, string status);
}
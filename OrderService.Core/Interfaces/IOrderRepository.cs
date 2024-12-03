using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
	Task UpdateOrderStatus(int id, string status);
}
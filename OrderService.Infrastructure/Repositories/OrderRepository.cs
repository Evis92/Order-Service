using OrderService.Core.Entities;
using OrderService.Core.Interfaces;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
	public OrderRepository(OrderDbContext context) : base(context)
	{
		
	}

	public async Task UpdateOrderStatus(int id, string status)
	{
		var order = await GetById(id);
		if (order != null)
		{
			order.Status = status;
			_dbSet.Update(order);
		}
	}
}
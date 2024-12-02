using OrderService.Core.Entities;
using OrderService.Core.Interfaces;

namespace OrderService.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
	public OrderRepository()
	{
		
	}
}
using OrderService.Application.Notifications;
using OrderService.Core.Entities;
using OrderService.Core.Interfaces;
using OrderService.Core.Interfaces.Order;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories;

namespace OrderService.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly OrderDbContext _dbContext;
	private readonly OrderSubject _orderSubject;
	public IOrderRepository Orders { get; }

	public UnitOfWork(OrderDbContext dbContext, OrderSubject orderSubject, IOrderRepository orderRepository)
	{
		_dbContext = dbContext;
		Orders = orderRepository;
		_orderSubject = orderSubject ?? new OrderSubject();
	}


	public IRepository<T> repository<T>() where T : class
	{
		return new Repository<T>(_dbContext);
	}

	public async Task NotifyOrderCreated(Order order)
	{
		_orderSubject.Notify(order);
	}

	public async Task Complete()
	{
		await _dbContext.SaveChangesAsync();
	}

	public void Dispose()
	{
		_dbContext.Dispose();
	}
}
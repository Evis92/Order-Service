using OrderService.Core.Interfaces;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly OrderDbContext _dbContext;
	public IOrderRepository Orders { get; set; }

	public UnitOfWork(OrderDbContext dbContext, IOrderRepository orderRepository)
	{
		_dbContext = dbContext;
		Orders = orderRepository;
	}



	public IRepository<T> repository<T>() where T : class
	{
		throw new NotImplementedException();
	}

	public Task Complete()
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}
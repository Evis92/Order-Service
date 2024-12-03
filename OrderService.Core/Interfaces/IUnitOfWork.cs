using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
	IOrderRepository Orders { get;  }
	IRepository<T> repository<T>() where T : class;

	Task NotifyOrderCreated(Order order);

	Task Complete();
}
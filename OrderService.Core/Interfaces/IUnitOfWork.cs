using OrderService.Core.Entities;
using OrderService.Core.Interfaces.Order;

namespace OrderService.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
	IOrderRepository Orders { get;  }
	IRepository<T> repository<T>() where T : class;

	Task NotifyOrderCreated(Entities.Order order);

	Task Complete();
}
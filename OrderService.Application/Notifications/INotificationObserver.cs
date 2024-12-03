using OrderService.Core.Entities;

namespace OrderService.Application.Notifications;

public interface INotificationObserver
{
	void Update(Order order);
}
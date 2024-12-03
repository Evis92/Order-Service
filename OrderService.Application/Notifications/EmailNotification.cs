using OrderService.Core.Entities;

namespace OrderService.Application.Notifications;

public class EmailNotification : INotificationObserver
{
	public void Update(Order order)
	{
		Console.WriteLine($"A new order has been placed: {order.CreatedDate}, {order.PizzaIds}");
	}
}
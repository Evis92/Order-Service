using OrderService.Core.Entities;

namespace OrderService.Application.Notifications;

public class OrderSubject
{
	private readonly List<INotificationObserver> _observers = new();

	public void Attach(INotificationObserver observer)
	{
		if (!_observers.Contains(observer))
		{
			_observers.Add(observer);
		}
	}

	public void Detach(INotificationObserver observer)
	{
		_observers.Remove(observer);
	}

	public void Notify(Order order)
	{
		foreach (var observer in _observers)
		{
			observer.Update(order);
		}
	}
}
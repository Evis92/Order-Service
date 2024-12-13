using System.Text;
using RabbitMQ.Client;

namespace OrderService.Infrastructure.RabbitMQ.Producers;

public class OrderServiceProducer
{
	private readonly RabbitMQConfiguration _config;

	public OrderServiceProducer(RabbitMQConfiguration config)
	{
		_config = config;
	}


	public void PublishOrderCreated(string orderId)
	{
	}
}
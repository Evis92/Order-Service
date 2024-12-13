namespace OrderService.Infrastructure.RabbitMQ.Consumers;

public class OrderServiceConsumer
{
	private readonly RabbitMQConfiguration _config;

	public OrderServiceConsumer(RabbitMQConfiguration config)
	{
		_config = config;
	}

	public void StartListening()
	{
	}
}
namespace OrderService.Infrastructure.RabbitMQ;

public class RabbitMQConfiguration
{
	public string HostName { get; set; } = "localhost";
	public string ExchangeName { get; set; } = "orderExchange";
	public string QueueName { get; set; } = "orderQueue";
	public string RoutingKey { get; set; } = ""; // Fanout använder oftast tom routingKey
}
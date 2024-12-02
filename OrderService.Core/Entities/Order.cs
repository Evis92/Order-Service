namespace OrderService.Core.Entities;

public class Order
{
	public int Id { get; set; }

	public int CustomerId { get; set; }

	public List<int> PizzaId { get; set; }
}
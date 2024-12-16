namespace OrderService.Core.Entities;

public class Order
{ 

	public int Id { get; set; }
	public string CustomerName { get; set; }
	public List<int> PizzaIds { get; set; }
	public string Status { get; set; } = "Pending";
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
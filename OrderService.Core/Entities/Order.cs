namespace OrderService.Core.Entities;

public class Order
{ 

	public int Id { get; set; }
	public string CustomerName { get; set; }
	public List<int> PizzaIds { get; set; } // Foreign keys till Pizza Service.
	public string Status { get; set; } = "Pending"; // default värde
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
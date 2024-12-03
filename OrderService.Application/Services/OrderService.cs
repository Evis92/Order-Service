using OrderService.Core.Entities;
using OrderService.Core.Interfaces;
using OrderService.Core.Interfaces.Order;

namespace OrderService.Application.Services;

public class OrderService : GenericService<Order>, IOrderService
{
	private readonly IUnitOfWork _unitOfWork;

	public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override async Task Add(Order order)
	{
		await _unitOfWork.Orders.Add(order);
		await _unitOfWork.Complete();
		await _unitOfWork.NotifyOrderCreated(order);
	}
}
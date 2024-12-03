using Microsoft.EntityFrameworkCore;
using OrderService.Application.Notifications;
using OrderService.Core.Interfaces;
using OrderService.Core.Interfaces.Order;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories;
using OrderService.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase("MyDatabase"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService.Application.Services.OrderService>();

builder.Services.AddSingleton<OrderSubject>(sp =>
{
	var orderSubject = new OrderSubject();
	orderSubject.Attach(new EmailNotification());
	return orderSubject;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



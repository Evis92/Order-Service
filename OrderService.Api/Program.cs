using Polly;
using System.Collections.Immutable;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Notifications;
using OrderService.Application.Services;
using OrderService.Core.Interfaces;
using OrderService.Core.Interfaces.Order;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories;
using OrderService.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<OrderDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); ;

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

// Retry-logik för databasanslutning
var policy = Policy.Handle<SqlException>()
	.WaitAndRetryAsync(30, attempt => TimeSpan.FromSeconds(5), // 30 försök med 5 sekunder mellan
		(exception, timeSpan, retryCount, context) =>
		{
			Console.WriteLine($"Retry {retryCount} failed, waiting {timeSpan.TotalSeconds} seconds.");
		});

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
	try
	{
		// Försök att ansluta till databasen
		await policy.ExecuteAsync(async () =>
		{
			// Försök att migrera databasen (om den inte redan är migrerad)
			await dbContext.Database.MigrateAsync();
			Console.WriteLine("Database connection succeeded and migration done.");
		});
	}
	catch (Exception ex)
	{
		// Hantera om alla försök misslyckas
		Console.WriteLine($"Could not connect to database {ex.Message}");
		throw;
	}
}

app.UseSwagger();
	app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

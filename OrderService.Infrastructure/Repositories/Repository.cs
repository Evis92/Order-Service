using OrderService.Core.Interfaces;

namespace OrderService.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
	public Task<T>? GetById(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<T>>? GetAll()
	{
		throw new NotImplementedException();
	}

	public Task Add(T entity)
	{
		throw new NotImplementedException();
	}

	public Task Update(T entity)
	{
		throw new NotImplementedException();
	}

	public Task Delete(int id)
	{
		throw new NotImplementedException();
	}
}
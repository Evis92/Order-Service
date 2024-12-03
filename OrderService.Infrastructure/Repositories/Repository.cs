using Microsoft.EntityFrameworkCore;
using OrderService.Core.Interfaces;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly OrderDbContext _dbContext;
	protected readonly DbSet<T> _dbSet;

	public Repository(OrderDbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<T>();
	}

	public async Task<T>? GetById(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task<IEnumerable<T>>? GetAll()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task Add(T entity)
	{
		await _dbSet.AddAsync(entity);
	}

	public async Task Update(T entity)
	{
		_dbSet.Update(entity);
	}

	public async Task Delete(int id)
	{
		var entity = await _dbSet.FindAsync(id);
		if (entity != null)
		{
			_dbSet.Remove(entity);
		}
	}
}
﻿using OrderService.Core.Interfaces;

namespace OrderService.Application.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
	public Task<IEnumerable<T>> GetAll()
	{
		throw new NotImplementedException();
	}

	public Task<T>? GetById(int id)
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
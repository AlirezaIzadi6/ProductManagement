﻿namespace Application.Interfaces;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> ListAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}

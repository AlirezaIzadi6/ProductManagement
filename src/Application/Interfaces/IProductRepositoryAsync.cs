using Domain.Entities;

namespace Application.Interfaces;

public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
{
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetProductsByCreatorAsync(string CreatorId);
    Task<bool> IsUniqueAsync(string name, DateOnly produceDate);
    Task<bool> IsUniqueAsync(string name, DateOnly produceDate, int id);
}

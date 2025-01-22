using Domain.Entities;

namespace Application.Interfaces;

public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
{
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetProductsByCreatorAsync(string CreatorId);
    Task<bool> IsUnique(string name, DateOnly produceDate);
}

using Domain.Entities;

namespace Application.Interfaces;

public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
{
    Task<IEnumerable<Product>> GetProductsByCreatorAsync(string CreatorId);
}

using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
{
    private readonly ApplicationDbContext _context;
    public ProductRepositoryAsync(ApplicationDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsByCreatorAsync(string creatorId)
    {
        return await _context.products.Where(p => p.CreatedByUserId == creatorId)
            .ToListAsync();
    }

    public async Task<bool> IsUnique(string name, DateOnly produceDate)
    {
        return await _context.products.AnyAsync(p => p.Name == name && p.ProduceDate == produceDate);
    }
}

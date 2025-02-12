using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using UnitTests.Helpers;

namespace UnitTests.Fixtures.Seeders;

public static class DataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        string productJsonPath = "Data/Product.json";
        var products = await JsonHelper.ExtractJsonData<List<Product>>(productJsonPath);
        context.products.AddRange(products);
        await context.SaveChangesAsync();
    }
}

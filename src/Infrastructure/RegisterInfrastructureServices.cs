using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Infrastructure.Services;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure;

public static class RegisterInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection"),
                b => b.MigrationsAssembly("Infrastructure"));
        });

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
        // Just a fake service for Identity package to work:
        services.AddTransient<IEmailSender<IdentityUser>, EmailSender>();

        return services;
    }
}

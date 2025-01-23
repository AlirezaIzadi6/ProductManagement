using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Mappers;
using System.Reflection;

namespace Application;

public static class RegisterApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}

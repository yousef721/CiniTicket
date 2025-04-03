using CineTicket.Application.Services;
using CineTicket.Core.Interfaces.Services;
using CineTicket.Core.Interfaces.UnitOfWork;
using CineTicket.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CineTicket.Application.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        // Register Repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>(); 

        // Register Services
        services.AddScoped<IMovieServices, MovieServices>();
        services.AddScoped<IIdentityServices, IdentityServices>();
        return services;
    }
}

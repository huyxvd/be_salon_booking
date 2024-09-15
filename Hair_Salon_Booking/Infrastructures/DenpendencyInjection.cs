using Application.Interfaces;
using Application.Services;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures;
public static class DenpendencyInjection
{
    public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<ICurrentTime, CurrentTime>();

        // ATTENTION: if you do migration please check file README.md
        services.AddDbContext<AppDbContext>(option => option.UseSqlServer(databaseConnection));

        // this configuration just use in-memory for fast develop
        //services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("test"));

        services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("test"));

        return services;
    }
}
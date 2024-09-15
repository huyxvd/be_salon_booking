using Application.Interfaces;
using Application.Services;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;
using Infrastructures.Repositories;

namespace Infrastructures;
public static class DenpendencyInjection
{
    public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddSingleton<ICurrentTime, CurrentTime>();

        // ATTENTION: if you do migration please check file README.md
        services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("DatabaseConnection"));

        // this configuration just use in-memory for fast develop
        //services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("test"));

        services.AddAutoMapper(typeof(Infrastructures.Mappers.MapperConfigurationsProfile).Assembly);

        return services;
    }
}
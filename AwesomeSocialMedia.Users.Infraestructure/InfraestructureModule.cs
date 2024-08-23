using AwesomeSocialMedia.Users.Core.Repositories;
using AwesomeSocialMedia.Users.Infraestructure.Persistence;
using AwesomeSocialMedia.Users.Infraestructure.Persistence.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AwesomeSocialMedia.Users.Infraestructure;

public static class InfraestructureModule
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AwesomeSocialMediaCs");
        services
            .AddDb(connectionString)
            .AddRepository();

        return services;
    }

    public static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<UsersDbContext>(opt => opt.UseSqlServer(
            connectionString,
            b => b.MigrationsAssembly("AwesomeSocialMedia.Users.Infraestructure")));

        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

}

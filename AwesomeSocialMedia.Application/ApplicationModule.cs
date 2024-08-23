using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeSocialMedia.Users.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediator();

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        //services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ApplicationModule)));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationModule)));

        return services;
    }
}

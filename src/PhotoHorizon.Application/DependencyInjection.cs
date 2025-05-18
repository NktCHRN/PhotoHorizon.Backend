using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoHorizon.Application.Behaviors;

namespace PhotoHorizon.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddValidatorsFromAssembly(typeof(IApplicationMarker).Assembly)
            .AddMediatR(cfg =>
            {
                cfg
                    .RegisterServicesFromAssembly(typeof(IApplicationMarker).Assembly)
                    .AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
    }
}

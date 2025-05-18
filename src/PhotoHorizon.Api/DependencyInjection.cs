using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace PhotoHorizon.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        
        services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            })
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        
        services.AddOpenApi();
        
        services.AddCors(opt => opt.AddPolicy("DEV_CORS", p => p
            .AllowAnyOrigin()           // TODO: Change this.
            .AllowAnyMethod()
            .AllowAnyHeader()));
        
        return services;
    }
}

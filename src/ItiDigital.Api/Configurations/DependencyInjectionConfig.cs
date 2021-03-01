using ItiDigital.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace ItiDigital.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Notifier>();

            return services;
        }
    }
}

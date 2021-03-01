using ItiDigital.Application.AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ItiDigital.Application
{
    public static class Bootstrap
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelMapping), typeof(ViewModelToDomainMapping));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ItiDigital.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var description = "Construa uma aplicação que exponha uma api web que valide se uma senha é válida.<br /><br />" +
                "<i>Input: Uma senha (string).</i><br />" +
                "<i>Output: Um boolean indicando se a senha é válida.</i><br /><br />" +
                "Considere uma senha sendo válida quando a mesma possuir as seguintes definições:<br />" +
                "<ul><li>Nove ou mais caracteres</li>" +
                "<li>Ao menos 1 dígito</li>" +
                "<li>Ao menos 1 letra minúscula</li>" +
                "<li>Ao menos 1 letra maiúscula</li>" +
                "<li>Ao menos 1 caractere especial (!@#$%^&*()-+)</li>" +
                "<li>Não possuir caracteres repetidos dentro do conjunto</li></ul>" +
                "<b>Nota:</b> <i>Espaços em branco não devem ser considerados como caracteres válidos.</i>";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Iti Digital - Backend Challenge",
                    Description = description,
                    Contact = new OpenApiContact { Name = "Adriano Gavioli", Email = "adriano.sgavioli@gmail.com" },
                    Version = "v1"
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Password Validator");
            });

            return app;
        }
    }
}

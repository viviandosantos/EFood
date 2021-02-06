using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFood.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "E-Food API",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 3.1 manipulação de produtos alimentícios de um catálogo",
                        Contact = new OpenApiContact
                        {
                            Name = "Vivian Santos",
                            Url = new Uri("https://github.com/viviandosantos")
                        }
                    });
            });
        }
    }
}

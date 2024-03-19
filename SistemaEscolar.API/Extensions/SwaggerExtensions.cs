using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace SistemaEscolar.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "Sistema Escolar",
                Version = "v1",
                Description = "Sistema escolar de apoyo al docente.",
                TermsOfService = new Uri("https://sebastianserrisuela.com.ar"),
                Contact = new OpenApiContact
                {
                    Name = "Sebastián Serrisuela",
                    Email = "sebaserri@gmail.com",
                    Url = new Uri("https://sebastianserrisuela.com.ar")
                },
                License = new OpenApiLicense
                {
                    Name = "License",
                    Url = new Uri("https://sebastianserrisuela.com.ar")
                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "JWT Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme,  new string[] {} }
                });

            });

            return services;
        }
    }
}

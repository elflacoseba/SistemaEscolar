using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaEscolar.Application.Interfaces;
using SistemaEscolar.Application.Services;
using System.Reflection;

namespace SistemaEscolar.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
                       
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IInstitutionApplication, InstitutionApplication>();
            services.AddScoped<IEducationalLevelApplication, EducationalLevelApplication>();

            return services;
        }
    }
}

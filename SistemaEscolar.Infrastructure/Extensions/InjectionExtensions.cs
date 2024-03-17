using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;
using SistemaEscolar.Infrastructure.Persistence.Repositories;

namespace SistemaEscolar.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(SistemaEscolarContext).Assembly.FullName;

            services.AddDbContext<SistemaEscolarContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("SistemaEscolarConnection"), b => b.MigrationsAssembly(assembly)),
                           ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return services;
        }
    }
}

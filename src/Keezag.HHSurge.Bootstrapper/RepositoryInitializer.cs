using Keezag.HHSurge.Domain;
using Keezag.HHSurge.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Keezag.HHSurge.Bootstrapper
{
    public static class RepositoryInitializer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}

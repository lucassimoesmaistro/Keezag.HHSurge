using Keezag.HHSurge.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keezag.HHSurge.Bootstrapper
{
    public static class ApplicationsInitializer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserApplication, UserApplication>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Keezag.Common.Log;

namespace Keezag.Common
{
    public static class LogServiceInitializer
    {
        public static Logger Logar { get; set; }
        public static IServiceCollection AddLog(this IServiceCollection services, string applicationName, string logFilesFolder)
        {
            Logar = new Logger(applicationName, logFilesFolder);

            return services.AddSingleton(Logar);
        }
    }
}

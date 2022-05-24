using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorreioTracker.ConfigHandler
{
    public static class ConfigJson
    {
        /// <summary>
        /// Instantiate the class with some info of the system
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            var emailBot = configuration.GetSection("AppSettings").GetSection("Parameters").Get<EmailBot>();
            var connections = configuration.GetSection("AppSettings").GetSection("Parameters").GetSection("ConnectionsStrings").Get<ConnectionsStrings>();

            SystemConfigJson config = new SystemConfigJson
            {
                EmailBot = emailBot,
                ConnectionsStrings = connections
            };

            services.AddSingleton<SystemConfigJson>(config);
        }
    }
}

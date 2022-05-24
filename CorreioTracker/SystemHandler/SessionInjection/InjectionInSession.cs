using CorreioTracker.Repository.Areas;
using CorreioTracker.Repository.EF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.SystemHandler.SessionInjection
{
    public static class InjectionInSession
    {
        /// <summary>
        /// Instantiate the Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        public static void Start(IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
    }
}

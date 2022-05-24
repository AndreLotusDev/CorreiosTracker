using AutoMapper;
using CorreioTracker.ConfigHandler;
using CorreioTracker.Context;
using CorreioTracker.DomainModels.MappingProfile;
using CorreioTracker.Repository.Dapper;
using CorreioTracker.SystemHandler.SessionInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CorreioTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Allow attualizes the page in real time
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();

            //Creates a json with some infos for DI
            ConfigJson.Start(services, Configuration);

            services.AddCors();

            //DI of AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            var connections = Configuration.GetSection("AppSettings").GetSection("Parameters").GetSection("ConnectionsStrings").Get<ConnectionsStrings>();
            services.AddEntityFrameworkNpgsql().AddDbContext<TrackerContext>(options => options.UseNpgsql(connections.BancoMain));

            services.AddScoped<DbSession>();

            //Configure the DI
            InjectionInSession.Start(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Libera o acesso da API ao correios
            app.UseCors(builder => builder.WithOrigins("https://www2.correios.com.br", "http://www2.correios.com.br"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

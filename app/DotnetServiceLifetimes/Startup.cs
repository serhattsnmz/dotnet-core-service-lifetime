using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestServices.Repository;
using TestServices.Services;

namespace TestServices
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;
        public Startup(IConfiguration _configuration, IWebHostEnvironment _env)
        {
            configuration = _configuration;
            env = _env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            // SERVICES
            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopeService>();
            services.AddTransient<TransientService>();

            // REPOSITORIES
            services.AddSingleton<SingletonRepo1>();        // Constructor Injection >> Scope cannot be used
            services.AddSingleton<SingletonRepo2>();        // IHttpContextAccessor
            services.AddSingleton<SingletonRepo3>();        // IServiceProvider >> Codes are different

            services.AddScoped<ScopeRepo1>();   // Constructor Injection
            services.AddScoped<ScopeRepo2>();   // IHttpContextAccessor
            services.AddScoped<ScopeRepo3>();   // IServiceProvider

            /// There is 4 way to use services:
            /// 
            /// 1. Constructor Injection
            ///     Created once in a class and all class functions use SAME instance event if instance is TRANCIENT!
            ///     Scope services cannot used as CI if service is singleton.
            ///     Independent of request
            ///     If want to use scope services in singleton services, use IServiceProvider or IHttpContextAccessor
            /// 
            /// 2. IServiceProvider
            ///     Singleton container for services
            ///     Independent of request
            ///     It can bu used even if there is no request.
            ///     It does not have scope services if used in singleton services. 
            ///         Even if IServiceProvider does not HAVE scope services, scope container CAN BE CREATED from it.
            ///     
            /// 3. IHttpContextAccessor ( Also named as RequestServices or HttpContext )
            ///     Scope container for services
            ///     Dependent of request
            ///     There must be request to use it, otherwise it rise exception
            ///     It has both scope and singleton services.

            /// NOTES:
            ///     Never inject Scoped & Transient services into Singleton service.
            ///     Never inject Transient services into scoped service.
            ///     
            /// USAGE:
            ///     Singleton:
            ///         Created only once and not destroyed until the end of the Application.
            ///         Like static variables.
            ///         Use where you need to maintain application wide state.
            ///         Singletons are also memory efficient.
            ///         Exp : Logging Service, Caching, App Configuration
            ///     Scope:
            ///         Created on request and delete after request ends.
            ///         Use where you need to maintain state withing a request.
            ///         If you do not know which one you should use, use scope.
            ///     Transient:
            ///         Always created new instance whenever app needs. 
            ///         Safest to create, but use more memory because create new instance has negative impact on performance.
            ///         Use for the lightweight service with little or no state.


            // SETTINGS
            services.AddMemoryCache();
            services.AddSession(option => { option.IdleTimeout = TimeSpan.FromHours(2); });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            /// 4. app.ApplicationServices
            ///     This is like IServiceProvider
            ///     This following codes runs once at startup.

            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | STARTUP");

            var singleton = app.ApplicationServices.GetRequiredService<SingletonService>();
            var transient = app.ApplicationServices.GetRequiredService<TransientService>();
            using (var scopeServices = app.ApplicationServices.CreateScope())
            {
                var scope = scopeServices.ServiceProvider.GetRequiredService<ScopeService>();

                singleton.WriteInfo();
                scope.WriteInfo();
                transient.WriteInfo();
            }

            /// ---------------------------------------------------

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ----- NEW REQUEST -----");
                Console.WriteLine(" ");
                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}"
                   );
            });
        }
    }
}

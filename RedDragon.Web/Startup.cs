using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace RedDragon.Web
{
    using static Ioc.Bootstraper;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //container IOC and Contexts
            Initializer(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(2000); // <-- add this line
                }
            });
        }

        //private void ConfigureCors(IApplicationBuilder appBuilder)
        //{
        //    appBuilder.UseCors();
                
        //        new CorsOptions
        //    {
        //        PolicyProvider = new CorsPolicyProvider
        //        {
        //            PolicyResolver = context =>
        //            {
        //                var policy = new CorsPolicy();
        //                policy.Headers.Add("Content-Type");
        //                policy.Headers.Add("Accept");
        //                policy.Headers.Add("Auth-Token");
        //                policy.Methods.Add("GET");
        //                policy.Methods.Add("POST");
        //                policy.Methods.Add("PUT");
        //                policy.Methods.Add("DELETE");
        //                policy.SupportsCredentials = true;
        //                policy.PreflightMaxAge = 1728000;
        //                policy.AllowAnyOrigin = true;
        //                return Task.FromResult(policy);
        //            }
        //        }
        //    });
        //}
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;

namespace RedDragon.Ioc
{
    using Application.Interface;
    using Application.Services;
    using Domain.Inteface.Service;
    using Domain.Inteface.Repository;
    using Repository;
    using Services;
    public static class Bootstraper
    {
        public static void Initializer(IServiceCollection services)
        {
            //Services
            services.AddScoped<IAviaoServiceApp, AviaoServiceApp>();
            services.AddScoped<IAviaoService, AviaoService>();
            services.AddScoped<IAviaoRepository, AviaoRepository>();

        }
    }
}

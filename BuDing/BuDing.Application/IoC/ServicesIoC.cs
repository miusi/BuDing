using System;
using System.Collections.Generic;
using System.Text; 
using BuDing.Infrastructure.DataLogic;
using BuDing.Infrastructure.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuDing.Application.IoC
{
    public static class ServicesIoC
    {
        //public static void ApplicationServicesIoC(this IServiceCollection services)
        //{
        //    services.AddScoped(typeof(IDataService<>), typeof(BaseBusinessLogic<>)); 
        //    services.AddScoped<BaseUserLogic, BaseUserLogic>(); 
        //}

        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            return services;
        }
    }
}

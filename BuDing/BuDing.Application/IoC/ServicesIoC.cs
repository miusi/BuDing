using System;
using System.Collections.Generic;
using System.Text;
using BuDing.Application.Services.Domain;
using BuDing.Application.Services.Standard;
using BuDing.Infrastructure.DataService;
using Microsoft.Extensions.DependencyInjection;

namespace BuDing.Application.IoC
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDataService<>), typeof(BaseBusinessLogic<>)); 
            services.AddScoped<BaseUserLogic, BaseUserLogic>(); 
        }
    }
}

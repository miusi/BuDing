
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuDing.Application.IoC
{
	using BuDing.Infrastructure.DataLogic;
	using BuDing.Infrastructure.DataService;
	using BuDing.Application.Services.Domain;
	using BuDing.Application.Services.Stardand;
	using BuDing.Application.Interfaces.Services;
	using BuDing.Application.Repositories.Domain;
	using BuDing.Application.Repositories.Standard;
	using BuDing.Application.Interfaces.IRepositories;

	public static class ServicesIoC
	{
		public static void ApplicationServicesIoC(this IServiceCollection services)
		{
			services.AddScoped(typeof(IService<>), typeof(ServiceBase<>));
			services.AddScoped<ISysUserService, SysUserService>();
		}

		public static void ApplicationRepositoryIoC(this IServiceCollection services)
		{
			//注入泛型仓储
			services.AddTransient(typeof(IRepository<>), typeof(EfCoreRepository<>));
			services.AddTransient(typeof(IRepository<,>), typeof(EfCoreRepository<,>));
			services.AddTransient<ISysUserRepository, SysUserRepository>();
		}

		public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
			where TContext : DbContext
		{
			services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
			return services;
		}
	}
}

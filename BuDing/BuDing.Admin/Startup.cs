
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuDing.Admin
{
	using BuDing.Application.IoC;
	using BuDing.Application.Context;

	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
			   .SetBasePath(env.ContentRootPath)
			   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)//增加环境配置文件，新建项目默认有
			   .AddEnvironmentVariables();
			Configuration = builder.Build(); 
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			#region 跨域
			//var urls =Configuration.GetConnectionString("AllowCors.AllowAllOrigin").Split(",");
			services.AddCors(options =>
			options.AddPolicy("AllowAllOrigin", builder =>
					builder.WithOrigins("http://localhost:9528")
							.AllowAnyMethod()
							.AllowAnyHeader()
							.AllowAnyOrigin()//允许任何来源的访问
							.AllowCredentials())//允许处理Cookie
			);
			#endregion

		

			services.AddDbContext<BuDingContext>(options =>
			 options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

			//使用扩展方法注入Uow依赖
			services.AddUnitOfWork<BuDingContext>();

			services.ApplicationRepositoryIoC();
			services.ApplicationServicesIoC();
			//mvc
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseCors("AllowAllOrigin");
			app.UseMvc();
		}
	}
}

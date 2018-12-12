
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
	using System.IO;
	using Microsoft.AspNetCore.Http;

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

		/// <summary>
		/// 配置信息项
		/// </summary>
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
			//Json首字母小写解决
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			//.AddJsonOptions(options=>options.SerializerSettings.ContractResolver=new Newtonsoft.Json.Serialization.DefaultContractResolver())
			//ASP.NET Core中提供了一个IHttpContextAccessor接口，HttpContextAccessor 默认实现了它简化了访问HttpContext。
			//它必须在程序启动时在IServicesCollection中注册，这样在程序中就能获取到HttpContextAccessor，并用来访问HttpContext。
			//services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
				{
					Version = "v1",
					Title = "BuDing.Admin Api"
				});
				//var basePath =  PlatformServices.Default.Application.ApplicationBasePath;
				////Set the comments path for the swagger json and ui.  
				//var xmlPath = Path.Combine(basePath, "BuDing.Admin.xml");
				//options.IncludeXmlComments(xmlPath);
			});

		
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

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuDing.Admin API V1");
			});
		}
	}
}

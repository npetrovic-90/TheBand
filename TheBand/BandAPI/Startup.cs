using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandAPI.DbContexts;
using BandAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace BandAPI
{
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
			//adding mvc
			services.AddControllers( setupAction => 
			{
				setupAction.ReturnHttpNotAcceptable = true;
			})
				
				//adding newtonsoft json support
				.AddNewtonsoftJson(setupAction => {
					setupAction.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver();
				})//adding xml support
				.AddXmlDataContractSerializerFormatters();


			//automapper
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			//repository register
			services.AddScoped<IBandAlbumRepository,BandAlbumRepository>();
			//custom mapping service
			services.AddScoped<IPropertyMappingService, PropertyMappingService>();
			//validation service for data shaping
			services.AddScoped<IPropertyValidationService, PropertyValidationService>();
			//
			services.AddResponseCaching();
			//dbcontext register
			services.AddDbContext<BandAlbumContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});
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
				app.UseExceptionHandler(appBuilder =>
				{
					appBuilder.Run(async c =>
					{
						c.Response.StatusCode = 500;
						await c.Response.WriteAsync("Something went wrong, try again later");
					});
				});
			}

			app.UseResponseCaching();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

using hailstone.core;
using hailstone.core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hailstone.api
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

			// create the datacontext to be used by the database-backed hailstone number generator
			// - the name of the database file is in the connection string
			services.AddDbContext<HailstoneDbContext>(options => options.UseSqlite(@"Data Source=hailstone.db;") );

			// the controller is expecting to be provided an instance of HailstoneNumberGenerator
			//services.AddSingleton<HailstoneNumberGenerator, NaiveHailstoneNumberGenerator>();
			// services.AddSingleton<HailstoneNumberGenerator, DatabaseHailstoneNumberGenerator>();
			services.AddScoped<HailstoneNumberGenerator, DatabaseHailstoneNumberGenerator>();

			services.AddHttpContextAccessor();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}

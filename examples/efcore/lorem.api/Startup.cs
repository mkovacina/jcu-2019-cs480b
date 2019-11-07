using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lorem.core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace lorem.api
{
	/// <summary>
	/// The startup class for this API
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="configuration">The configuration for the application</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		/// <summary>
		/// Configure the services for the application.
		/// </summary>
		/// <param name="services">The collection of service.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
			// setup to use a sqlite database
			services.AddDbContext<LoremContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Transient);
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app">The application builder</param>
		/// <param name="env">The hosting environment</param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();

			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<LoremContext>();
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
				PopulateDatabase(context);
			}
		}

		private static void PopulateDatabase(LoremContext context)
		{
			var author1 = new Author()
			{
				FirstName = "Dr",
				LastName = "Seuss"
			};
			var author2 = new Author()
			{
				FirstName = "Mr",
				LastName = "Spock"
			};
			var author3 = new Author()
			{
				FirstName = "Mr",
				LastName = "Tuvok"
			};

			var document1 = new Document();
			document1.Title = "Green Eggs and Ham";

			var document2 = new Document();
			document2.Title = "Vulcan, A Primer";

			var document3 = new Document();
			document3.Title = "Green Eggs and Vulcans";

			var da1 = new DocumentAuthor() { Document = document1, Author = author1 };
			var da2 = new DocumentAuthor() { Document = document2, Author = author2 };
			var da3 = new DocumentAuthor() { Document = document3, Author = author1 };
			var da4 = new DocumentAuthor() { Document = document3, Author = author2 };
			var da5 = new DocumentAuthor() { Document = document3, Author = author3 };

			context.AddRange(da1, da2, da3, da4, da5);

			context.SaveChanges();
		}
	}
}

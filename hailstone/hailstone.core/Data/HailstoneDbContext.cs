using hailstone.core.Models;
using Microsoft.EntityFrameworkCore;

namespace hailstone.core.Data
{
	public sealed class HailstoneDbContext : DbContext
	{
		public HailstoneDbContext(DbContextOptions<HailstoneDbContext> options) : base(options)
		{

		}

		public DbSet<HailstoneData> Facts { get; set; }

		// we can separate the data binding from the model
		// this allows for more flexibility in the future
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<HailstoneData>().HasKey(x => x.Number);
			base.OnModelCreating(builder);
		}

		// IMPORTANT
		// initially, you need to create the "migrations"
		// View > Other Windows > Package Manager Console
		// from the console, select the default project from the dropdown to the project where your DbContext is (e.g., Hailstone.Core)
		// Then execute the command "Add-Migration initial"
		// -- you should see new files generated in your project under a "migrations" folder
		// from the console, select the default project from the dropdown to the project where your database will be  (e.g., Hailstone.API)
		// Then execute the command "Update-Migration"
		// - this will create the database
	}
}

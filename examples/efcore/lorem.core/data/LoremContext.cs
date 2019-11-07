using Microsoft.EntityFrameworkCore;

namespace lorem.core
{

	/// <summary>
	/// The database context that provides access to document and other data.
	/// </summary>
	public class LoremContext : DbContext
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public LoremContext(DbContextOptions options) : base(options)
		{

		}

		/// <summary>
		/// Used to access documents in the database.
		/// </summary>
		public DbSet<Document> Documents { get; set; }

		/// <summary>
		/// Used to access authors in the database.
		/// </summary>
		public DbSet<Author> Authors { get; set; }

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DocumentAuthor>().HasKey(x => new {x.DocumentId, x.AuthorId});
		}
	}
}

using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using lorem.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace lorem.console
{
	class Program
	{
		// [miko]
		// entering the world of async
		// see the stackoverflow entry below if your visual studio 
		// is complaining about not finding a main method.
		// https://stackoverflow.com/a/44254451/167160
		static async Task Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			// [miko]
			// even in a plain console application, we can use the dependency injection functionality
			// provided by microsoft...it is not limited to only aspnet.core applications.
			var container = new ServiceCollection();

			// setup to use a sqlite database
			container.AddDbContext<LoremContext>(options => options.UseSqlite("Data Source=lorem.db"),ServiceLifetime.Transient);
			// [miko]
			// getting a context that has already been disposed.
			// yup.
			// AddDbContext is implicitly scoped.
			// explicitly set the service lifetime
			// https://github.com/aspnet/EntityFrameworkCore/issues/4988

			var provider = container.BuildServiceProvider();

			using (var context = provider.GetService<LoremContext>())
			{
				// [miko]
				// good for testing
				// bad for production...
				await context.Database.EnsureDeletedAsync();

				// [miko]
				// if the database doesn't exist it will be created
				// this should ideally only be run once in an application lifetime
				// this only ensure existence, this does not perform migrations.
				var dbDidntExist = await context.Database.EnsureCreatedAsync();

				if (dbDidntExist)
				{
					await PopulateDatabase(context);
				}
			}

			using (var context = provider.GetService<LoremContext>())
			{
				var documents = context.Documents
										.Include(d => d.DocumentAuthor)
										.ThenInclude(x => x.Author);

				foreach (var document in documents)
				{
					Console.WriteLine($"document.id = {document.Id}");
					Console.WriteLine($"document.title = {document.Title}");

					foreach (var author in document.Authors)
					{
						Console.WriteLine($"document.author.id = {author.Id}");
						Console.WriteLine($"document.author.firstname = {author.FirstName}");
						Console.WriteLine($"document.author.firstname = {author.LastName}");
					}

					Console.WriteLine();
				}
			}

			Console.ReadKey();
		}

		private static async Task PopulateDatabase(LoremContext context)
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

			var da1 = new DocumentAuthor() {Document = document1, Author = author1};
			var da2 = new DocumentAuthor() {Document = document2, Author = author2};
			var da3 = new DocumentAuthor() {Document = document3, Author = author1};
			var da4 = new DocumentAuthor() {Document = document3, Author = author2};
			var da5 = new DocumentAuthor() {Document = document3, Author = author3};

			context.AddRange(da1, da2, da3, da4, da5);

			await context.SaveChangesAsync();
		}
	}
}

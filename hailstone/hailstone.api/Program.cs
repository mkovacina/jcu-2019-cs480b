using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace hailstone.api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) => 
			WebHost.CreateDefaultBuilder(args)
					.UseStartup<Startup>();
		

		public static IWebHostBuilder CreateWebHostBuilder2(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
		}
	}
}

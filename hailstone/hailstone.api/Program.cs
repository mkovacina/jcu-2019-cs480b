using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace hailstone.api
{

	// be sure to set the working directory for debugging to be the base directory for hailstone.api
	// https://stackoverflow.com/a/56195726

	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost
						.CreateDefaultBuilder(args)
						.ConfigureLogging(logBuilder =>
						{
							logBuilder.ClearProviders(); // removes all providers from LoggerFactory
							logBuilder.AddConsole();
							logBuilder.AddTraceSource("Information, Trace"); // Add Trace listener provider
							logBuilder.SetMinimumLevel(LogLevel.Trace);
							//logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
						})
						.UseStartup<Startup>();
		}

		public static IWebHostBuilder CreateWebHostBuilder2(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
		}
	}
}

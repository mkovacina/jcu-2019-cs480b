using hailstone.core;
using Microsoft.Extensions.Logging;
using System;

// https://oeis.org/A006577

namespace hailstone.console
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			LoggerFactory loggerFactory = new LoggerFactory();
#pragma warning disable CS0618 // Type or member is obsolete
			loggerFactory.AddConsole(includeScopes:true);
#pragma warning restore CS0618 // Type or member is obsolete

			//ILogger logger = loggerFactory.CreateLogger("logger");
			ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

			using (logger.BeginScope("user is {name}","mike"))
			{
				logger.LogDebug("debug");
				logger.LogInformation("hello");
				logger.LogError("this is an error");
			}


			if (args.Length == 0)
			{
				Console.Error.WriteLine("usage: dotnet hailstone.console <input as integer>");

				// !!!!!
				// yes, c# has goto
				// yes, i'm using it here to get us down to the 
				//		ReadKey() to keep the console from disappearing
				//		while debugging in visual studio
				// no, you don't really have many opportunities to use it in real life
				// caveat programmor
				goto end;
			}

			bool result = long.TryParse(args[0], out long input);

			if (!result)
			{
				Console.Error.WriteLine("The input was not an integer.");
				goto end;
			}

			HailstoneNumberGenerator generator = new NaiveHailstoneNumberGenerator();

			//Console.WriteLine(generator.ID);
			DoStuff_Injected(generator);
			DoStuff_NotInjected();

			long hailstoneNumber = generator.ComputeHailstoneNumber(input);

		//	Console.WriteLine(hailstoneNumber);

			System.Collections.Generic.IEnumerable<long> sequence = generator.GenerateSequence(input);

			foreach (long item in sequence)
			{
				//Console.Write(item + ", ");
			}
			end:
			Console.ReadKey();
		}

		/// <summary>
		/// This method illustrates method level dependency injection.
		/// </summary>
		/// <param name="generator">An instance of a HailstoneNumberGenerator.</param>
		/// <remarks>
		/// The method needs to do something, and it needs a HailstoneNumberGenerator to do it.
		/// 
		/// The generator is provided to the method as a parameter.
		/// 
		/// The parameter is specified as an interface so that the concrete instance of the type can change
		/// without the the method itself being changed.  It also allows the method to be used/reused in more cases.
		///
		/// For example
		///		DoStuff_Injected(new NaiveHailstoneNumberGenerator());
		///		DoStuff_Injected(new OptimizedHailstoneNumberGenerator());
		/// </remarks>
		public static void DoStuff_Injected(HailstoneNumberGenerator generator)
		{
			generator.ComputeHailstoneNumber(0);
		}

		/// <summary>
		/// This method does not use dependency injection at the method level.
		/// </summary>
		/// <remarks>
		/// This method uses "new" to instantiate a new instance of a specific type of HailstoneNumberGenerator.
		///
		/// If this is really what is needed, then it is ok.
		/// But when you need to change the type of generator used, you will need to scour your code for all instances,
		/// change those places, and do more testing (which is ok because you have a lot of automated tests, right?)
		/// </remarks>
		public static void DoStuff_NotInjected()
		{
			NaiveHailstoneNumberGenerator generator = new NaiveHailstoneNumberGenerator();
			generator.ComputeHailstoneNumber(0);
		}
	}
}

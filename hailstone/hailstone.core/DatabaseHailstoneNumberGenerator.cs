using hailstone.core.Data;
using hailstone.core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hailstone.core
{
	public sealed class DatabaseHailstoneNumberGenerator : HailstoneNumberGenerator
	{
		private NaiveHailstoneNumberGenerator generator = new NaiveHailstoneNumberGenerator();
		private HailstoneDbContext Context { get; }
		private ILogger<DatabaseHailstoneNumberGenerator> Logger { get; }


		public DatabaseHailstoneNumberGenerator(HailstoneDbContext context, ILogger<DatabaseHailstoneNumberGenerator> logger)
		{
			Context = context;
			Logger = logger;
		}

		public Guid ID => Guid.NewGuid();

		public long ComputeHailstoneNumber(long input)
		{
			//return Context.Facts.Find(input).HailstoneNumber;
			//return Context.Facts.Find(input)?.HailstoneNumber ?? 0;

			Logger.LogTrace($"Computing for {input}");

			var result = Context.Facts.Find(input);

			if (result == null)
			{
				result = new HailstoneData();
				result.Number = input;
				result.HailstoneNumber = generator.ComputeHailstoneNumber(input);

				Context.Facts.Add(result);
				Context.SaveChanges();
			}

			return result.HailstoneNumber;
		}

		public IEnumerable<long> GenerateSequence(long input)
		{
			return generator.GenerateSequence(input);
		}

		public HailstoneInformation ComputeHailstoneInformation(long input)
		{
			var hn = ComputeHailstoneNumber(input);
			var model = new HailstoneInformation(input, hn, Enumerable.Empty<long>());
			return model;
		}
	}
}

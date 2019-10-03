using System;
using System.Collections.Generic;

namespace hailstone.core
{
	public sealed class NaiveHailstoneNumberGenerator : HailstoneNumberGenerator
	{
		// one place to initialize a readonly
		private readonly Guid guid = Guid.NewGuid();

		public NaiveHailstoneNumberGenerator()
		{
			// the other place to initialize a readonly
			guid = Guid.NewGuid();
		}

		
		/// <inheritdoc/>
		public long ComputeHailstoneNumber(long input)
		{
			// "guard" statement
			if (input <= 0) return 0;

			// sometimes handling the special cases in a 
			// special way makes the rest of the logic easier
			if (input == 1) return 1;

			long hailstoneNumber = 0;

			while (input != 1)
			{
				if (input % 2 == 0)
				{
					input /= 2;
				}
				else
				{
					input = input * 3 + 1;
				}

				hailstoneNumber++;
			}

			return hailstoneNumber;
		}

		/// <inheritdoc/>
		public IEnumerable<long> GenerateSequence(long seed)
		{
			// "guard" statement
			if (seed <= 0) return new long[] { 0 };

			// sometimes handling the special cases in a 
			// special way makes the rest of the logic easier
			if (seed == 1) return new long[] { 1 };

			List<long> list = new List<long> { seed };

			while (seed != 1)
			{
				if (seed % 2 == 0)
				{
					seed /= 2;
				}
				else
				{
					seed = seed * 3 + 1;
				}

				list.Add(seed);
			}



			return list;
		}

		public Guid ID => guid;
	}
}
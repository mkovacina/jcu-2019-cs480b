using System;
using System.Collections.Generic;
using System.Text;

namespace hailstone.core
{
	class DefaultHailstoneNumberGenerator : HailstoneNumberGenerator
	{
		public long ComputeHailstoneNumber(long input)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<long> GenerateSequence(long input)
		{
			throw new NotImplementedException();
		}

		public Guid ID { get; }
	}
}

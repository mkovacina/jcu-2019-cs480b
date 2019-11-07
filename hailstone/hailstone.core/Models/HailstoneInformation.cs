using System.Collections.Generic;

namespace hailstone.core
{
	/// <summary>
	/// Holds hailstone information about a number
	/// </summary>
	public class HailstoneInformation
	{
		public HailstoneInformation(long number, long hailstoneNumber, IEnumerable<long> sequence)
		{
			Number = number;
			HailstoneNumber = hailstoneNumber;
			Sequence = sequence;

			//var list = new List<long>();
			//var info = new HailstoneInformation(1, 2, list);
			//// info.sequence is empty
			//list.Add(5);
			//// info.sequence is {5}
		}

		/// <summary>
		/// The input number
		/// </summary>
		public long Number { get;  }
		/// <summary>
		/// The computed hailstone number
		/// </summary>
		public long HailstoneNumber { get; }
		/// <summary>
		/// The hailstone sequence.
		/// </summary>
		public IEnumerable<long> Sequence { get; }
	}
}
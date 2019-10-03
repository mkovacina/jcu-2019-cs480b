using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hailstone.api.Models
{
	public class HailstoneData
	{
		public long Number {get; set;}
		public IEnumerable<long> Sequence {get;set;}
	}
}

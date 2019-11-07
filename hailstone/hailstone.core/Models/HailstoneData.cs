using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace hailstone.core.Models
{
	public class HailstoneData
	{
		//[Key]
		public long Number { get; set; }
		public long HailstoneNumber { get; set; }
	}
}

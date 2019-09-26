using System;
using System.Collections.Generic;
using System.Linq;

namespace hailstone.console
{
	internal class EnumerableUsages
	{
		public static void Sample1()
		{
			int[] data = new int[10];

			for (int x = 0; x < data.Length; x++)
			{
				Console.WriteLine(x);
			}

			foreach (int datum in data)
			{
				Console.WriteLine(datum);
			}

			IEnumerable<int> idata = data;

			foreach (int idatum in idata)
			{
				Console.WriteLine(idatum);
			}

			IEnumerable<int> embedded()
			{
				foreach (int j in idata)
				{
					yield return j;
				}
			}

			foreach (int k in embedded())
			{
				Console.WriteLine(k);
			}

			idata.Max();

			if (idata.Count() == 0)
			{

			}

			IEnumerable<int> result = from x in idata
									  where x % 2 == 0
									  select x;

			var result2 = idata.Where(x => x%2 == 0);

			foreach( var m in idata )
			{
				if (m % 2 == 0)
				{
					// do something
				}
			}

			var list = new List<int>(data);
			var a1 = list.Count;
			var a2 = list.Count();
			var dictionary = new Dictionary<int, string>();

			var x2 = from x in dictionary
					 where x.Key > 7
					 select x;




		}
	}
}

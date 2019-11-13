using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

//using Newtonsoft.Json;

namespace hailsone.sample.client
{
	class Program
	{
		private static readonly HttpClient client = new HttpClient();

		//
		// example data
		// 
		// {"number":5,"hailstoneNumber":5,"sequence":[]}
		//

		private static async Task Main(string[] args)
		{
			Thread.Sleep(10000);
			
			var rawData = await client.GetStringAsync("http://localhost:5000/api/hailstone/5");
			Console.WriteLine(rawData);
#region hide
			HailstoneData data = JsonConvert.DeserializeObject<HailstoneData>(rawData);
			Console.WriteLine(data.Number);
			Console.WriteLine(data.HailstoneNumber);
			int count = 0;
			foreach (var x in data.Sequence)
			{
				Console.WriteLine($"[{count}] {x}");
				count++;
			}
#endregion
		}

#region hide
		public class HailstoneData
		{
			public long Number { get; set; }
			public long HailstoneNumber { get; set; }
			public List<long>Sequence  { get; set; }
		}
#endregion hide
	}
}

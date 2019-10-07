using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hailstone.api.Models;
using hailstone.core;
using Microsoft.AspNetCore.Mvc;

namespace hailstone.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HailstoneController : ControllerBase
	{
		 private HailstoneNumberGenerator Generator { get; }

		public HailstoneController(HailstoneNumberGenerator generator)
		{
			Generator = generator;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<HailstoneData> Get(int id)
		{
			var data = new HailstoneData();
			data.Number = Generator.ComputeHailstoneNumber(id);
			data.Sequence = Generator.GenerateSequence(id);
			
			return data;
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}

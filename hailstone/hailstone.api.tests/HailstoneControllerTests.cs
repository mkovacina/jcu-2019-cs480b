using hailstone.core;
using hailstone.api.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test_Get_Success()
		{
			var generator = new NaiveHailstoneNumberGenerator();
			var controller = new HailstoneController(generator);

			ActionResult<HailstoneInformation> actual = controller.Get(5);
			HailstoneInformation value = actual.Value;

			Assert.That(value.Number, Is.EqualTo(5));
			Assert.That(value.Sequence, Is.EquivalentTo(new long[]{5,16,8,4,2,1}));
		}
	}
}
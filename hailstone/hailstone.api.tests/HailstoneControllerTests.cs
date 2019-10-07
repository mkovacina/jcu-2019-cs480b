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

			var actual = controller.Get(5);

			Assert.That(actual.Value.Number, Is.EqualTo(5));
			Assert.That(actual.Value.Sequence, Is.EquivalentTo(new long[]{5,16,8,4,2,1}));
		}
	}
}
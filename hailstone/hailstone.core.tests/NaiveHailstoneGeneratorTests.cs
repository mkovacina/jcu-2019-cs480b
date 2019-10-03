using hailstone.core;
using NUnit.Framework;

namespace Tests
{
	public class Tests
	{
		[OneTimeSetUp]
		public void OneTimeSetup()
		{
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test()
		{
			// arrange
			var generator = new NaiveHailstoneNumberGenerator();
			long input = 5;
			long expected = 5;
			
			// act
			var actual = generator.ComputeHailstoneNumber(input);

			// assert
			Assert.AreEqual(expected, actual);
		}
	}
}
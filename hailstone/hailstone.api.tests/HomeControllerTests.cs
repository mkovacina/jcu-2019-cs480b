using hailstone.api.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace hailstone.api.tests
{
	[TestFixture]
	public sealed class HomeControllerTests
	{
		// this class comes from the Microsoft.AspNetCore.Mvc.Testing NuGet package
		private readonly WebApplicationFactory<Startup> _factory;

		public HomeControllerTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Test]
		public async void LinkGeneratorTest()
		{
			// Arrange
			var client = _factory.CreateClient();

			// Act
			var response = await client.GetAsync("");

			// Assert
			response.EnsureSuccessStatusCode(); // Status Code 200-299
			//Assert.Equal("text/html; charset=utf-8",
			//	response.Content.Headers.ContentType.ToString());
		}
	}
}

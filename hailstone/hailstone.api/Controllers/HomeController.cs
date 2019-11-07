using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace hailstone.api.Controllers
{
	[Route("api/")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private LinkGenerator LinkGenerator { get; }
		private IHttpContextAccessor Context { get; }

		public HomeController(IHttpContextAccessor context, LinkGenerator linkGenerator)
		{
			LinkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
			Context = context ?? throw new ArgumentNullException(nameof(context));
		}

		// GET: api/Home
		[HttpGet]
		public IEnumerable<Data> Get()
		{
			var data = new Data();
			data.Key = "hailstone";
			data.Uri =  LinkGenerator.GetUriByAction(Context.HttpContext,
								   controller: "Hailstone",
								   action: "Get"
							   );
			return new Data[] { data };
		}

		public class Data
		{
			public string Key { get; set; }
			public string Uri { get; set; }
		}
	}
}

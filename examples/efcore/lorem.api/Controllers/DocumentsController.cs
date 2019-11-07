using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lorem.core;
using Microsoft.AspNetCore.Mvc;
using Document = lorem.api.models.Document;

namespace lorem.api.Controllers
{
	/// <summary>
	/// API controller for the '/documents' resource.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentsController : ControllerBase
	{
		private readonly LoremContext _context;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="context">The database context to data access.</param>
		public DocumentsController(LoremContext context)
		{
			_context = context;
		}

		// GET api/values
		/// <summary>
		/// Returns all the documents.
		/// </summary>
		/// <returns>All the documents.</returns>
		[HttpGet]
		public IEnumerable<Document> Get()
		{
			return from document in _context.Documents
				   select new Document()
				   {
					   Title = document.Title
				   };
		}

		// GET api/values/5
		/// <summary>
		/// Gets a specific document.
		/// </summary>
		/// <param name="id">The id of the document to get.</param>
		/// <returns>The document.</returns>
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}
	}
}

namespace lorem.core
{
	/// <summary>
	/// Represents the many-to-many relation between documents and authors
	/// </summary>
	public class DocumentAuthor
	{
		/// <summary>
		/// The ID of the document related to the author.
		/// </summary>
		public long DocumentId { get; set; }
		/// <summary>
		/// The document related to the author.
		/// </summary>
		public Document Document { get; set; }

		/// <summary>
		/// The ID of the author related to the document.
		/// </summary>
		public long AuthorId { get; set; }
		/// <summary>
		/// The author related to the document.
		/// </summary>
		public Author Author { get; set; }
	}
}
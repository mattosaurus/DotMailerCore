using System;
using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class Document
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string FileName { get; set; }

		public int FileSize { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}

using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class DocumentFolder
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<DocumentFolder> ChildFolders { get; set; }
	}
}

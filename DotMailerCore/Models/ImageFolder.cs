using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class ImageFolder
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<ImageFolder> ChildFolders { get; set; }
	}
}

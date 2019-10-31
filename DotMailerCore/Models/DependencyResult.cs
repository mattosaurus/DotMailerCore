using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class DependencyResult
	{
		public List<Dependency> Dependencies { get; set; }

		public bool Result { get; set; }
	}
}

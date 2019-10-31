using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class Dependency
	{
		public BusinessObjectType Type { get; set; }

		public int ObjectId { get; set; }
	}
}

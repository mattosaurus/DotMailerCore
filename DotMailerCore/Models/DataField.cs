using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class DataField
	{
		public string Name { get; set; }

		public DataType Type { get; set; }

		public DataFieldVisibility Visibility { get; set; }
	}
}

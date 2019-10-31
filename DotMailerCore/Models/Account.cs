using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class Account
	{
		public int Id { get; set; }

        public List<Property> Properties { get; set; }
    }
}

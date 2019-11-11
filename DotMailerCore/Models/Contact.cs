using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class Contact
	{
		public int Id { get; set; }

		public string Email { get; set; }

		public ContactOptInType OptInType { get; set; }

		public ContactEmailType EmailType { get; set; }

		public List<DataField> DataFields { get; set; }

		public ContactStatus Status { get; set; }
	}
}

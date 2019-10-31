using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class Contact
	{
		public int Id { get; set; }

		public string Email { get; set; }

		public ContactOptInTypes OptInType { get; set; }

		public ContactEmailTypes EmailType { get; set; }

		public List<DataField> DataFields { get; set; }

		public ContactStatuses Status { get; set; }
	}
}

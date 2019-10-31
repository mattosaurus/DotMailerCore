using System;
using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class ContactSuppression
	{
		public Contact SuppressedContact { get; set; }

		public DateTime DateRemoved { get; set; }

		public ContactStatuses Reason { get; set; }
	}
}

using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class ContactResubscription
	{
		public Contact UnsubscribedContact { get; set; }

		public string PreferredLocale { get; set; }

		public string ReturnUrlToUseIfChallenged { get; set; }
	}
}

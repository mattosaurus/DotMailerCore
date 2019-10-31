using System;
using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class CampaignContactPageView
	{
		public int ContactId { get; set; }

		public string Email { get; set; }

		public string Url { get; set; }

		public DateTime DateViewed { get; set; }
	}
}

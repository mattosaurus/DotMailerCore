using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class CampaignContactSocialBookmarkView
	{
		public int ContactId { get; set; }

		public string Email { get; set; }

		public string BookmarkName { get; set; }

		public int NumViews { get; set; }
	}
}

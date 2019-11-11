using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class Campaign
	{
		public int Id { get; set; }

        public string Name { get; set; }

		public string Subject { get; set; }

		public string FromName { get; set; }

		public CampaignFromAddress FromAddress { get; set; }

		public string HtmlContent { get; set; }

		public string PlainTextContent { get; set; }

		public CampaignReplyAction ReplyAction { get; set; }

		public string ReplyToAddress { get; set; }

		public bool IsSplitTest { get; set; }

		public CampaignStatus Status { get; set; }
	}
}

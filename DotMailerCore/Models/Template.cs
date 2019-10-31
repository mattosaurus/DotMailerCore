using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class Template
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Subject { get; set; }

		public string FromName { get; set; }

		public string HtmlContent { get; set; }

		public string PlainTextContent { get; set; }

		public CampaignReplyActions ReplyAction { get; set; }

		public string ReplyToAddress { get; set; }
	}
}

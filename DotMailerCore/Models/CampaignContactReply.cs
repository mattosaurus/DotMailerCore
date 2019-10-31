using System;
using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class CampaignContactReply
	{
		public int ContactId { get; set; }

		public string Email { get; set; }

		public string FromAddress { get; set; }

		public string ToAddress { get; set; }

		public string Subject { get; set; }

		public string Message { get; set; }

		public bool IsHtml { get; set; }

		public DateTime DateReplied { get; set; }

		public CampaignReplyTypes ReplyType { get; set; }
	}
}

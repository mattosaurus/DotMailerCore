using DotMailerCore.Models.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Models
{
    public class SplitTestCampaign
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public List<string> Subjects { get; set; }

        public List<string> FromNames { get; set; }

        public List<CampaignFromAddress> FromAddresses { get; set; }

        public List<string> HtmlContents { get; set; }

        public List<string> PlainTextContents { get; set; }

        public CampaignReplyAction ReplyAction { get; set; }

        public string ReplyToAddress { get; set; }

        public bool IsSplitTest { get; set; }

        public CampaignStatus Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class CampaignContactRoiDetail
	{
		public int ContactId { get; set; }

		public string Email { get; set; }

		public string MarkerName { get; set; }

		public RoiDetailDataType DataType { get; set; }

		public DateTime DateEntered { get; set; }
	}
}

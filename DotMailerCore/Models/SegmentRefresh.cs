using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class SegmentRefresh
	{
		public int Id { get; set; }

		public SegmentRefreshStatuses Status { get; set; }
	}
}

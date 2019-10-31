using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class SplitTestSendOptions
	{
		public SplitTestMetrics TestMetric { get; set; }

		public int TestPercentage { get; set; }

		public int TestPeriodHours { get; set; }
	}
}

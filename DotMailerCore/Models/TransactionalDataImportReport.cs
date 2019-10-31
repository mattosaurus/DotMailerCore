using System.Collections.Generic;

namespace DotMailerCore.Models
{
	public class TransactionalDataImportReport
	{
		public int TotalItems { get; set; }

		public int TotalImported { get; set; }

		public int TotalRejected { get; set; }

		public List<TransactionalDataImportReportFault> Faults { get; set; }
	}
}

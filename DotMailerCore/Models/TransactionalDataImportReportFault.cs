using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class TransactionalDataImportReportFault
	{
		public string Key { get; set; }

		public TransactionalDataImportFaultReason Reason { get; set; }
	}
}
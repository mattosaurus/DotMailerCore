using System;
using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class TransactionalDataImport
	{
		public Guid Id { get; set; }

		public TransactionalDataImportStatus Status { get; set; }
	}
}

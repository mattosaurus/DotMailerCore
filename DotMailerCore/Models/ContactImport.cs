using System;
using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class ContactImport
	{
		public Guid Id { get; set; }

		public ContactImportStatus Status { get; set; }
	}
}

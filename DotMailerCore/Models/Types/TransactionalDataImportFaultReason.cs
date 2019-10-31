namespace DotMailerCore.Models.Types
{
	public enum TransactionalDataImportFaultReason
	{
		InvalidClientKey,
		InvalidContactIdentifier,
		InvalidJson,
		DuplicateKey,
		ContactIdDoesNotExist,
		ContactEmailDoesNotExist,
		NotAvailableInThisVersion
	}
}

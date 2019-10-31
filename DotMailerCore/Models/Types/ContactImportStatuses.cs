namespace DotMailerCore.Models.Types
{
	public enum ContactImportStatuses
	{
		Finished,
		NotFinished,
		RejectedByWatchdog,
		InvalidFileFormat,
		Unknown,
		Failed,
		ExceedsAllowedContactLimit,
		NotAvailableInThisVersion
	}
}

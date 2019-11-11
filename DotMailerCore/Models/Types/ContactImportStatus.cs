namespace DotMailerCore.Models.Types
{
	public enum ContactImportStatus
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

namespace DotMailerCore.Models.Types
{
	public enum ContactStatus
	{
		Subscribed,
		Unsubscribed,
		SoftBounced,
		HardBounced,
		IspComplained,
		MailBlocked,
		PendingOptIn,
		DirectComplaint,
		Deleted,
		SharedSuppression,
		Suppressed,
		NotAllowed,
		DomainSuppression,
		NoMxRecord,
		NotAvailableInThisVersion
	}
}

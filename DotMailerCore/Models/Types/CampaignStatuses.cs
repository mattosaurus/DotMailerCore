namespace DotMailerCore.Models.Types
{
	public enum CampaignStatuses
	{
		Unsent,
		Sending,
		Sent,
		Paused,
		Cancelled,
		RequiresSystemApproval,
		RequiresSMSApproval,
		RequiresWorkflowApproval,
		Triggered,
		NotAvailableInThisVersion
	}
}

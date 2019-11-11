namespace DotMailerCore.Models.Types
{
	public enum CampaignStatus
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

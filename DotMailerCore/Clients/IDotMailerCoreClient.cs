using DotMailerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotMailerCore.Clients
{
    public interface IDotMailerCoreClient
    {
        Task<Account> GetAccountInformationAsync();

        Task EmptyRecycleBinAsync();

        Task<AddressBook> CreateAddressBookAsync(AddressBook addressBook);

        Task DeleteAddressBookAsync(int id);

        Task<AddressBook> UpdateAddressBookAsync(AddressBook addressBook);

        Task<AddressBook> GetAddressBookAsync(int id);

        Task<List<AddressBook>> GetAddressBooksAsync(int select, int skip);

        Task<List<AddressBook>> GetPrivateAddressBooksAsync(int select, int skip);

        Task<List<AddressBook>> GetPublicAddressBooksAsync(int select, int skip);

        Task<Campaign> CreateCampaignAsync(Campaign campaign);

        Task<SplitTestCampaign> CreateSplitTestCampaignAsync(SplitTestCampaign splitTestCampaign);

        Task<Campaign> UpdateCampaignAsync(Campaign campaign);

        Task<Campaign> CopyCampaignAsync(int id);

        Task DeleteCampaignAsync(int id);

        Task<CampaignSend> SendCampaignAsync(CampaignSend campaignSend);

        Task<CampaignSend> SendTimeOptimisedCampaignAsync(CampaignSend campaignSend);

        Task<CampaignSend> GetCampaignSendStatusAsync(Guid id);

        Task<Attatchment> AddCampaignAttachmentAsync(int id, Attatchment attatchment);

        Task RemoveCampaignAttachmentAsync(int campaignId, int documentId);

        Task<List<Attatchment>> GetCampaignAttachmentsAsync(int campaignId);

        Task<List<Campaign>> GetCampaignsAsync(int select, int skip);

        Task<List<Campaign>> GetCampaignsSentToAddressBookAsync(int campaignId, int select, int skip);

        Task<List<Campaign>> GetCampaignsSentToSegmentBookAsync(int segmentId, int select, int skip);

        Task<Campaign> GetCampaignAsync(int campaignId);

        Task<Campaign> GetCampaignWithDetailsAsync(int campaignId);

        Task<CampaignSummary> GetCampaignSummaryAsync(int campaignId);
    }
}

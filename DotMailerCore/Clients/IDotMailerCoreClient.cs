using ApiBaseClient;
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

        Task<Attachment> AddCampaignAttachmentAsync(int id, Attachment attatchment);

        Task RemoveCampaignAttachmentAsync(int campaignId, int documentId);

        Task<List<Attachment>> GetCampaignAttachmentsAsync(int campaignId);

        Task<List<Campaign>> GetCampaignsAsync(int select, int skip);

        Task<List<Campaign>> GetCampaignsSentToAddressBookAsync(int addressBookId, int select, int skip);

        Task<List<Campaign>> GetCampaignsSentToSegmentAsync(int segmentId, int select, int skip);

        Task<List<AddressBook>> GetCampaignAddressBooksAsync(int campaignId, int select, int skip);

        Task<List<Campaign>> GetCampaignsWithActivitySinceDateAsync(int campaignId, DateTime dateTime, int select, int skip);

        Task<Campaign> GetCampaignAsync(int campaignId);

        Task<Campaign> GetCampaignWithDetailsAsync(int campaignId);

        Task<CampaignSummary> GetCampaignSummaryAsync(int campaignId);

        Task<List<CampaignContactOpen>> GetCampaignOpensAsync(int campaignId, int select, int skip);

        Task<List<CampaignContactOpen>> GetCampaignOpensAsync(int campaignId, int contactId, int select, int skip);

        Task<List<CampaignContactOpen>> GetCampaignOpensAsync(int campaignId, DateTime dateTime, int select, int skip);

        Task<List<CampaignContactSummary>> GetCampaignActivityAsync(int campaignId, int select, int skip);

        Task<List<CampaignContactSummary>> GetCampaignActivityAsync(int campaignId, int contactId, int select, int skip);

        Task<List<CampaignContactSummary>> GetCampaignActivityAsync(int campaignId, DateTime dateTime, int select, int skip);

        Task<List<CampaignContactClick>> GetCampaignClicksAsync(int campaignId, int select, int skip);

        Task<List<CampaignContactClick>> GetCampaignClicksAsync(int campaignId, int contactId, int select, int skip);

        Task<List<CampaignContactClick>> GetCampaignClicksAsync(int campaignId, DateTime dateTime, int select, int skip);

        Task<List<CampaignContactClick>> GetCampaignClicksWithLinkGroupsAsync(int campaignId, int select, int skip);

        Task<List<CampaignContactClick>> GetCampaignClicksWithLinkGroupsAsync(int campaignId, int contactId, int select, int skip);

        Task<List<CampaignContactClick>> GetCampaignClicksWithLinkGroupsAsync(int campaignId, DateTime dateTime, int select, int skip);

        Task<List<CampaignContactPageView>> GetCampaignPageViewsAsync(int campaignId, int contactId, int select, int skip);

        Task<List<CampaignContactPageView>> GetCampaignPageViewsSinceDateAsync(int campaignId, DateTime dateTime, int select, int skip);

        Task<List<CampaignContactReply>> GetCampaignRepliesAsync(int campaignId, int contactId, int select, int skip);

        Task<List<CampaignContactRoiDetail>> GetCampaignROIAsync(int campaignId, int contactId, int select, int skip);

        Task<List<CampaignContactRoiDetail>> GetCampaignROIAsync(int campaignId, DateTime dateTime, int select, int skip);

        Task<List<CampaignContactSocialBookmarkView>> GetCampaignSocialBookmarkViewsAsync(int campaignId, int select, int skip);

        Task<List<CampaignContactSocialBookmarkView>> GetCampaignSocialBookmarkViewsAsync(int campaignId, int contactId, int select, int skip);

        Task<List<Contact>> GetCampaignHardBouncesAsync(int campaignId, int select, int skip);
    }
}

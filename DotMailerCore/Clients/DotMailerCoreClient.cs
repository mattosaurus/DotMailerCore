using ApiBaseClient;
using DotMailerCore.Clients;
using DotMailerCore.Helpers;
using DotMailerCore.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotMailerCore
{
    public class DotMailerCoreClient : BaseClient, IDotMailerCoreClient
    {
        private readonly IRestSerializer _serializer;

        public DotMailerCoreClient(ICacheService cache, IDeserializer deserializer, IRestSerializer serializer, IOptions<DotMailerCoreOptions> options)
            : base(options.Value.BaseUrl, cache, deserializer, options.Value.Authenticator)
        {
            _serializer = serializer;
        }

        public DotMailerCoreClient(IDeserializer serializer, IOptions<DotMailerCoreOptions> options)
            : base(options.Value.BaseUrl, options.Value.Authenticator, serializer) { }

        public DotMailerCoreClient(IOptions<DotMailerCoreOptions> options)
            : base(options.Value.BaseUrl, options.Value.Authenticator) { }

        #region Account

        /// <summary>
        /// Gets a summary of information about the current status of the account.
        /// </summary>
        public async Task<Account> GetAccountInformationAsync()
        {
            var request = new RestRequest("account-info") { JsonSerializer = _serializer };
            return await MakeRequestAsync<Account>(request);
        }

        /// <summary>
        /// Permanently deletes everything in the recycle bin.
        /// </summary>
        public async Task EmptyRecycleBinAsync()
        {
            var request = new RestRequest("accounts/empty-recycle-bin/", Method.POST) { JsonSerializer = _serializer };
            await MakeRequestAsync(request);
        }

        #endregion

        #region Address

        /// <summary>
        /// Creates an address book.
        /// </summary>
        public async Task<AddressBook> CreateAddressBookAsync(AddressBook addressBook)
        {
            var request = new RestRequest("/address-books", Method.POST) { JsonSerializer = _serializer };
            request.AddJsonBody(addressBook);

            return await MakeRequestAsync<AddressBook>(request);
        }

        /// <summary>
        /// Deletes an address book by ID.
        /// </summary>
        public async Task DeleteAddressBookAsync(int id)
        {
            var request = new RestRequest("/address-books/{id}", Method.DELETE) { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);

            await MakeRequestAsync(request);
        }

        /// <summary>
        /// Updates an address book by ID.
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public async Task<AddressBook> UpdateAddressBookAsync(AddressBook addressBook)
        {
            var request = new RestRequest("/address-books/{id}", Method.PUT) { JsonSerializer = _serializer };
            request.AddParameter("id", addressBook.Id, ParameterType.UrlSegment);
            request.AddJsonBody(addressBook);

            return await MakeRequestAsync<AddressBook>(request);
        }

        /// <summary>
        /// Gets an address book by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AddressBook> GetAddressBookAsync(int id)
        {
            var request = new RestRequest("/address-books/{id}") { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await MakeRequestAsync<AddressBook>(request);
        }

        /// <summary>
        /// Gets all address books.
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<AddressBook>> GetAddressBooksAsync(int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/address-books/") { JsonSerializer = _serializer };
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<AddressBook>>(request);
        }

        /// <summary>
        /// Gets all private address books.
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<AddressBook>> GetPrivateAddressBooksAsync(int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/address-books/private") { JsonSerializer = _serializer };
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<AddressBook>>(request);
        }

        /// <summary>
        /// Gets all public address books.
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<AddressBook>> GetPublicAddressBooksAsync(int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/address-books/public") { JsonSerializer = _serializer };
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<AddressBook>>(request);
        }

        #endregion

        #region Campaigns

        /// <summary>
        /// Creates a campaign.
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        public async Task<Campaign> CreateCampaignAsync(Campaign campaign)
        {
            var request = new RestRequest("/campaigns", Method.POST) { JsonSerializer = _serializer };
            request.AddJsonBody(campaign);

            return await MakeRequestAsync<Campaign>(request);
        }

        /// <summary>
        /// Creates a split test campaign.
        /// </summary>
        /// <param name="splitTestCampaign"></param>
        /// <returns></returns>
        public async Task<SplitTestCampaign> CreateSplitTestCampaignAsync(SplitTestCampaign splitTestCampaign)
        {
            var request = new RestRequest("/campaigns/split-test", Method.POST) { JsonSerializer = _serializer };
            request.AddJsonBody(splitTestCampaign);

            return await MakeRequestAsync<SplitTestCampaign>(request);
        }

        /// <summary>
        /// Updates a given campaign.
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        public async Task<Campaign> UpdateCampaignAsync(Campaign campaign)
        {
            var request = new RestRequest("/campaigns/{id}", Method.PUT) { JsonSerializer = _serializer };
            request.AddParameter("id", campaign.Id, ParameterType.UrlSegment);
            request.AddJsonBody(campaign);

            return await MakeRequestAsync<Campaign>(request);
        }

        /// <summary>
        /// Copies a given campaign, returning the new campaign.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Campaign> CopyCampaignAsync(int id)
        {
            var request = new RestRequest("/campaigns/{id}/copy", Method.POST) { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await MakeRequestAsync<Campaign>(request);
        }

        /// <summary>
        /// Deletes a campaign.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCampaignAsync(int id)
        {
            var request = new RestRequest("/campaigns/{id}", Method.DELETE) { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);

            await MakeRequestAsync(request);
        }

        /// <summary>
        /// Sends a specified campaign to one or more address books, segments or contacts, either as an immediate or scheduled send.
        /// </summary>
        /// <param name="campaignSend"></param>
        /// <returns></returns>
        public async Task<CampaignSend> SendCampaignAsync(CampaignSend campaignSend)
        {
            var request = new RestRequest("/campaigns/send", Method.POST) { JsonSerializer = _serializer };
            request.AddJsonBody(campaignSend);

            return await MakeRequestAsync<CampaignSend>(request);
        }

        /// <summary>
        /// Sends a specified campaign to one or more address books, segments or contacts at the most appropriate time based upon their previous opens.
        /// </summary>
        /// <param name="campaignSend"></param>
        /// <returns></returns>
        public async Task<CampaignSend> SendTimeOptimisedCampaignAsync(CampaignSend campaignSend)
        {
            var request = new RestRequest("/campaigns/send-time-optimised", Method.POST) { JsonSerializer = _serializer };
            request.AddJsonBody(campaignSend);

            return await MakeRequestAsync<CampaignSend>(request);
        }

        /// <summary>
        /// Gets a campaign send status using send ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CampaignSend> GetCampaignSendStatusAsync(Guid id)
        {
            var request = new RestRequest("/campaigns/send/{id}") { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await MakeRequestAsync<CampaignSend>(request);
        }

        /// <summary>
        /// Adds a document to a campaign as an attachment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attatchment"></param>
        /// <returns></returns>
        public async Task<Attatchment> AddCampaignAttachmentAsync(int id, Attatchment attatchment)
        {
            var request = new RestRequest("/campaigns/{id}/attachments", Method.POST) { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddJsonBody(attatchment);

            return await MakeRequestAsync<Attatchment>(request);
        }

        /// <summary>
        /// Removes an attachment from a campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public async Task RemoveCampaignAttachmentAsync(int campaignId, int documentId)
        {
            var request = new RestRequest("/campaigns/{campaignId}/attachments/{documentId}", Method.DELETE) { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("documentId", documentId, ParameterType.UrlSegment);

            await MakeRequestAsync(request);
        }

        /// <summary>
        /// Gets documents that are currently attached to a campaign
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <returns></returns>
        public async Task<List<Attatchment>> GetCampaignAttachmentsAsync(int campaignId)
        {
            var request = new RestRequest("/campaigns/{campaignId}/attachments") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);

            return await MakeRequestAsync<List<Attatchment>>(request);
        }

        /// <summary>
        /// Gets all campaigns
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaignsAsync(int select, int skip)
        {
            var request = new RestRequest("/campaigns") { JsonSerializer = _serializer };
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<Campaign>>(request);
        }

        /// <summary>
        /// Gets any campaigns that have been sent to an address book
        /// </summary>
        /// <param name="campaignId">The ID of the address book or segment, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL</param>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaignsSentToAddressBookAsync(int campaignId, int select, int skip)
        {
            var request = new RestRequest("/address-books/{campaignId}/campaigns") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<Campaign>>(request);
        }

        /// <summary>
        /// Gets any campaigns that have been sent to a segment
        /// </summary>
        /// <param name="campaignId">The ID of the address book or segment, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL</param>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaignsSentToSegmentBookAsync(int segmentId, int select, int skip)
        {
            var request = new RestRequest("/address-books/{segmentId}/campaigns") { JsonSerializer = _serializer };
            request.AddParameter("segmentId", segmentId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<Campaign>>(request);
        }

        /// <summary>
        /// Gets a campaign by ID
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <returns></returns>
        public async Task<Campaign> GetCampaignAsync(int campaignId)
        {
            var request = new RestRequest("/campaigns/{campaignId}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);

            return await MakeRequestAsync<Campaign>(request);
        }

        /// <summary>
        /// Gets a campaign by ID, along with all its details
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <returns></returns>
        public async Task<Campaign> GetCampaignWithDetailsAsync(int campaignId)
        {
            var request = new RestRequest("/campaigns/{campaignId}/with-details") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);

            return await MakeRequestAsync<Campaign>(request);
        }

        public async Task<CampaignSummary> GetCampaignSummaryAsync(int campaignId)
        {
            var request = new RestRequest("/campaigns/{campaignId}/summary") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);

            return await MakeRequestAsync<CampaignSummary>(request);
        }

        #endregion
    }
}

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
    public class DotMailerCoreClient : IDotMailerCoreClient
    {
        private readonly IRestSerializer _serializer;
        private readonly IBaseClient _baseClient;
        private readonly ILogger<IDotMailerCoreClient> _logger;

        public DotMailerCoreClient(ICacheService cache, IRestSerializer serializer, IOptions<DotMailerCoreOptions> options, ILoggerFactory loggerFactory)
        {
            _serializer = serializer;
            _baseClient = new BaseClient(options.Value.BaseUrl, cache, options.Value.ContentTypes, options.Value.Deserializer, options.Value.Authenticator, loggerFactory);
            _logger = loggerFactory.CreateLogger<IDotMailerCoreClient>();
        }

        public DotMailerCoreClient(IBaseClient baseClient, IRestSerializer serializer, ILoggerFactory loggerFactory)
        {
            _serializer = serializer;
            _baseClient = baseClient;
            _logger = loggerFactory.CreateLogger<IDotMailerCoreClient>();
        }

        #region Account

        /// <summary>
        /// Gets a summary of information about the current status of the account.
        /// </summary>
        public async Task<Account> GetAccountInformationAsync()
        {
            var request = new RestRequest("account-info") { JsonSerializer = _serializer };
            return await _baseClient.MakeRequestAsync<Account>(request);
        }

        /// <summary>
        /// Permanently deletes everything in the recycle bin.
        /// </summary>
        public async Task EmptyRecycleBinAsync()
        {
            var request = new RestRequest("accounts/empty-recycle-bin/", Method.POST) { JsonSerializer = _serializer };
            await _baseClient.MakeRequestAsync(request);
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

            return await _baseClient.MakeRequestAsync<AddressBook>(request);
        }

        /// <summary>
        /// Deletes an address book by ID.
        /// </summary>
        public async Task DeleteAddressBookAsync(int id)
        {
            var request = new RestRequest("/address-books/{id}", Method.DELETE) { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);

            await _baseClient.MakeRequestAsync(request);
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

            return await _baseClient.MakeRequestAsync<AddressBook>(request);
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

            return await _baseClient.MakeRequestAsync<AddressBook>(request);
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

            return await _baseClient.MakeRequestAsync<List<AddressBook>>(request);
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

            return await _baseClient.MakeRequestAsync<List<AddressBook>>(request);
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

            return await _baseClient.MakeRequestAsync<List<AddressBook>>(request);
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

            return await _baseClient.MakeRequestAsync<Campaign>(request);
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

            return await _baseClient.MakeRequestAsync<SplitTestCampaign>(request);
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

            return await _baseClient.MakeRequestAsync<Campaign>(request);
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

            return await _baseClient.MakeRequestAsync<Campaign>(request);
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

            await _baseClient.MakeRequestAsync(request);
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

            return await _baseClient.MakeRequestAsync<CampaignSend>(request);
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

            return await _baseClient.MakeRequestAsync<CampaignSend>(request);
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

            return await _baseClient.MakeRequestAsync<CampaignSend>(request);
        }

        /// <summary>
        /// Adds a document to a campaign as an attachment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attatchment"></param>
        /// <returns></returns>
        public async Task<Attachment> AddCampaignAttachmentAsync(int id, Attachment attatchment)
        {
            var request = new RestRequest("/campaigns/{id}/attachments", Method.POST) { JsonSerializer = _serializer };
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddJsonBody(attatchment);

            return await _baseClient.MakeRequestAsync<Attachment>(request);
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

            await _baseClient.MakeRequestAsync(request);
        }

        /// <summary>
        /// Gets documents that are currently attached to a campaign
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <returns></returns>
        public async Task<List<Attachment>> GetCampaignAttachmentsAsync(int campaignId)
        {
            var request = new RestRequest("/campaigns/{campaignId}/attachments") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);

            return await _baseClient.MakeRequestAsync<List<Attachment>>(request);
        }

        /// <summary>
        /// Gets all campaigns
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaignsAsync(int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns") { JsonSerializer = _serializer };
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<Campaign>>(request);
        }

        /// <summary>
        /// Gets any campaigns that have been sent to an address book
        /// </summary>
        /// <param name="addressBookId">The ID of the address book or segment, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL</param>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaignsSentToAddressBookAsync(int addressBookId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/address-books/{addressBookId}/campaigns") { JsonSerializer = _serializer };
            request.AddParameter("addressBookId", addressBookId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<Campaign>>(request);
        }

        /// <summary>
        /// Gets any campaigns that have been sent to a segment
        /// </summary>
        /// <param name="segmentId">The ID of the address book or segment, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL</param>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaignsSentToSegmentAsync(int segmentId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/address-books/{segmentId}/campaigns") { JsonSerializer = _serializer };
            request.AddParameter("segmentId", segmentId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<Campaign>>(request);
        }

        /// <summary>
        /// Gets all sent campaigns, which have had activity (e.g. clicks, opens) after a specified date
        /// </summary>
        /// <param name="dateTime">The date from which campaigns with activity will be returned, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL</param>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaignsWithActivityAsync(DateTime dateTime, int select, int skip)
        {
            var request = new RestRequest("/campaigns/with-activity-since/{dateTime}") { JsonSerializer = _serializer };
            request.AddParameter("dateTime", dateTime.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<Campaign>>(request);
        }

        /// <summary>
        /// Gets any address books and segments that a campaign has ever been sent to
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL</param>
        /// <returns></returns>
        public async Task<List<AddressBook>> GetCampaignAddressBooksAsync(int campaignId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/address-books") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<AddressBook>>(request);
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

            return await _baseClient.MakeRequestAsync<Campaign>(request);
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

            return await _baseClient.MakeRequestAsync<Campaign>(request);
        }

        /// <summary>
        /// Gets a summary of reporting information for a specified campaign
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <returns></returns>
        public async Task<CampaignSummary> GetCampaignSummaryAsync(int campaignId)
        {
            var request = new RestRequest("/campaigns/{campaignId}/summary") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);

            return await _baseClient.MakeRequestAsync<CampaignSummary>(request);
        }

        /// <summary>
        /// Gets a list of campaign opens
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactOpen>> GetCampaignOpensAsync(int campaignId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/opens") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactOpen>>(request);
        }

        /// <summary>
        /// Gets a list of campaign opens for a contact
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="contactId">The ID of the contact, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactOpen>> GetCampaignOpensAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}/opens") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactOpen>>(request);
        }

        /// <summary>
        /// Gets a list of opens for a campaign after a specified date
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="dateTime">The date from which any opens for the campaign are returned, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactOpen>> GetCampaignOpensAsync(int campaignId, DateTime dateTime, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/opens/since-date/{dateTime}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("dateTime", dateTime.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactOpen>>(request);
        }

        /// <summary>
        /// Gets a list of contacts who were sent a campaign, with their activity
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactSummary>> GetCampaignActivityAsync(int campaignId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactSummary>>(request);
        }

        /// <summary>
        /// Gets activity for a given contact and given campaign
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="contactId">The ID of the contact, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactSummary>> GetCampaignActivityAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactSummary>>(request);
        }

        /// <summary>
        /// Gets a list of contacts who were sent a campaign, and retrieves only those contacts who showed activity (e.g. they clicked, opened) after a specified date
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="dateTime">The date from which any campaign activity is returned, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactSummary>> GetCampaignActivityAsync(int campaignId, DateTime dateTime, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/since-date/{dateTime}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("dateTime", dateTime.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactSummary>>(request);
        }

        /// <summary>
        /// Gets a list of campaign link clicks
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactClick>> GetCampaignClicksAsync(int campaignId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/clicks") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactClick>>(request);
        }

        /// <summary>
        /// Gets a list of campaign link clicks for a contact
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="contactId"></param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactClick>> GetCampaignClicksAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}/clicks") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactClick>>(request);
        }

        /// <summary>
        /// Gets a list of link clicks for a campaign after a specified date
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="dateTime"></param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactClick>> GetCampaignClicksAsync(int campaignId, DateTime dateTime, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/clicks/since-date/{dateTime}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("dateTime", dateTime.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactClick>>(request);
        }

        /// <summary>
        /// Gets a list of campaign link clicks with assigned link groups
        /// </summary>
        /// <param name="campaignId">This is the ID of the campaign, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactClick>> GetCampaignClicksWithLinkGroupsAsync(int campaignId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/clicks-with-groups") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactClick>>(request);
        }

        /// <summary>
        /// Gets a list of campaign link clicks, with assigned link groups, for a contact
        /// </summary>
        /// <param name="campaignId">This is the ID of the campaign, which needs to be included within the URL</param>
        /// <param name="contactId">This is the ID of the contact, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactClick>> GetCampaignClicksWithLinkGroupsAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}/clicks-with-groups") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactClick>>(request);
        }

        /// <summary>
        /// Gets a list of link clicks for a campaign, with assigned link groups, after a specified date
        /// </summary>
        /// <param name="campaignId">This is the ID of the campaign, which needs to be included within the URL</param>
        /// <param name="dateTime">The date from which any campaign clicks are returned, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactClick>> GetCampaignClicksWithLinkGroupsAsync(int campaignId, DateTime dateTime, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/clicks-with-groups/since-date/{dateTime}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("dateTime", dateTime.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactClick>>(request);
        }

        /// <summary>
        /// Gets a list of page views for a specific campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactPageView>> GetCampaignPageViewsAsync(int campaignId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/page-views") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactPageView>>(request);
        }

        /// <summary>
        /// Gets a list of page views for a specific campaign for a contact
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="contactId">The ID of the contact, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactPageView>> GetCampaignPageViewsAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}/page-views") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactPageView>>(request);
        }

        /// <summary>
        /// Gets a list of page views for a campaign after a specified date
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="dateTime">The date from which any campaign page views are returned, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactPageView>> GetCampaignPageViewsAsync(int campaignId, DateTime dateTime, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/page-views/since-date/{dateTime}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("dateTime", dateTime.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactPageView>>(request);
        }

        /// <summary>
        /// Gets a list of campaign replies for a contact
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="contactId">The ID of the contact, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactReply>> GetCampaignRepliesAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}/replies") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactReply>>(request);
        }

        /// <summary>
        /// Gets a list of ROI information for a campaign for a contact
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="contactId">The ID of the contact, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactRoiDetail>> GetCampaignROIAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}/roi-details") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactRoiDetail>>(request);
        }

        /// <summary>
        /// Retrieves a list of ROI information for a campaign after a specified date
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="dateTime">The date from which any ROI activity is returned, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactRoiDetail>> GetCampaignROIAsync(int campaignId, DateTime dateTime, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/roi-details/since-date/{dateTime}") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("dateTime", dateTime.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactRoiDetail>>(request);
        }

        /// <summary>
        /// Gets campaign social bookmark views for a campaign
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactSocialBookmarkView>> GetCampaignSocialBookmarkViewsAsync(int campaignId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/social-bookmark-views") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactSocialBookmarkView>>(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="contactId"></param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<CampaignContactSocialBookmarkView>> GetCampaignSocialBookmarkViewsAsync(int campaignId, int contactId, int select = 1000, int skip = 0)
        {
            var request = new RestRequest("/campaigns/{campaignId}/activities/{contactId}/social-bookmark-views") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<CampaignContactSocialBookmarkView>>(request);
        }

        /// <summary>
        /// Gets a list of contacts who hard bounced when sent a particular campaign
        /// </summary>
        /// <param name="campaignId">The ID of the campaign, which needs to be included within the URL</param>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<Contact>> GetCampaignHardBouncesAsync(int campaignId, int select = 1000, int skip = 0, bool withFullDate = false)
        {
            var request = new RestRequest("/campaigns/{campaignId}/hard-bouncing-contacts") { JsonSerializer = _serializer };
            request.AddParameter("campaignId", campaignId, ParameterType.UrlSegment);
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);
            request.AddParameter("withFullDate", withFullDate, ParameterType.QueryString);

            return await _baseClient.MakeRequestAsync<List<Contact>>(request);
        }

        #endregion
    }
}

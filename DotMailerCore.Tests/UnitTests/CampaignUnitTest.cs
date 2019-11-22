using DotMailerCore.Clients;
using DotMailerCore.Models;
using DotMailerCore.Models.Types;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotMailerCore.Tests.UnitTests
{
    public class CampaignUnitTest
    {
        [Fact]
        public async Task CreateCampaign_ReturnsACampaignResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<Campaign>(Constants.CampaignCreateContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<Campaign>(mockRestResponse.Object);
            var campaign = TestFactory.GetCampaign();

            // Act
            var response = await client.CreateCampaignAsync(campaign);

            // Assert
            var model = Assert.IsAssignableFrom<Campaign>(response);
        }

        [Fact]
        public async Task CreateSplitTestCampaign_ReturnsASplitTestCampaignResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<SplitTestCampaign>(Constants.CampaignSplitTestCreateContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<SplitTestCampaign>(mockRestResponse.Object);
            var campaign = TestFactory.GetSplitTestCampaign();

            // Act
            var response = await client.CreateSplitTestCampaignAsync(campaign);

            // Assert
            var model = Assert.IsAssignableFrom<SplitTestCampaign>(response);
        }

        [Fact]
        public async Task UpdateCampaign_ReturnsACampaignResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<Campaign>(Constants.CampaignUpdateContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<Campaign>(mockRestResponse.Object);
            var campaign = TestFactory.GetCampaign();

            // Act
            var response = await client.UpdateCampaignAsync(campaign);

            // Assert
            var model = Assert.IsAssignableFrom<Campaign>(response);
            Equals(model.Id, campaign.Id);
        }

        [Fact]
        public async Task CopyCampaign_ReturnsACampaignResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<Campaign>(Constants.CampaignCopyContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<Campaign>(mockRestResponse.Object);
            var campaign = TestFactory.GetCampaign();

            // Act
            var response = await client.UpdateCampaignAsync(campaign);

            // Assert
            var model = Assert.IsAssignableFrom<Campaign>(response);
            Equals(model.Id, campaign.Id);
        }

        [Fact]
        public async Task DeleteCampaign()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse();
            var client = TestFactory.CreateDotMailerCoreClientWithResponse(mockRestResponse.Object);
            var campaignId = TestFactory.GetCampaignId();

            // Act
            await client.DeleteCampaignAsync(campaignId);
        }

        [Fact]
        public async Task SendCampaign_ReturnsACampaignSendResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<CampaignSend>(Constants.CampaignSendContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<CampaignSend>(mockRestResponse.Object);
            var campaignSend = TestFactory.GetCampaignSend();

            // Act
            var response = await client.SendCampaignAsync(campaignSend);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSend>(response);
        }

        [Fact]
        public async Task SendTimeOptimisedCampaign_ReturnsACampaignSendResponse()
        {
            // Arrange
            var campaignSend = TestFactory.GetCampaignSend();
            var mockRestResponse = TestFactory.CreateMockRestResponse<CampaignSend>(Constants.CampaignSendTimeOptimisedContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<CampaignSend>(mockRestResponse.Object);

            // Act
            var response = await client.SendTimeOptimisedCampaignAsync(campaignSend);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSend>(response);
        }

        [Fact]
        public async Task GetCampaignSendStatus_ReturnsACampaignSendStatusResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<CampaignSend>(Constants.CampaignSendStatusContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<CampaignSend>(mockRestResponse.Object);
            var campaignSendId = TestFactory.GetCampaignSendId();

            // Act
            var response = await client.GetCampaignSendStatusAsync(campaignSendId);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSend>(response);
        }

        [Fact]
        public async Task AddCampaignAttachment_ReturnsAnAttachmentResponse()
        {
            // Arrange
            var campaignId = TestFactory.GetCampaignId();
            var attatchment = TestFactory.GetCampaignAttatchment();
            var mockRestResponse = TestFactory.CreateMockRestResponse<Attachment>(Constants.CampaignAddCampaignAttatchmentContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<Attachment>(mockRestResponse.Object);

            // Act
            var response = await client.AddCampaignAttachmentAsync(campaignId, attatchment);

            // Assert
            var model = Assert.IsAssignableFrom<Attachment>(response);
        }

        [Fact]
        public async Task RemoveCampaignAttachment()
        {
            // Arrange
            var campaignId = TestFactory.GetCampaignId();
            var campaignAttatchmentId = TestFactory.GetCampaignAttatchmentId();
            var mockRestResponse = TestFactory.CreateMockRestResponse();
            var client = TestFactory.CreateDotMailerCoreClientWithResponse(mockRestResponse.Object);

            // Act
            await client.RemoveCampaignAttachmentAsync(campaignId, campaignAttatchmentId);
        }

        [Fact]
        public async Task GetCampaignAttatchments_ReturnsAnAttatchmentsListResponse()
        {
            // Arrange
            var campaignId = TestFactory.GetCampaignId();
            var mockRestResponse = TestFactory.CreateMockRestResponse<List<Attachment>>(Constants.CampaignCampaignAttatchmentsContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<List<Attachment>>(mockRestResponse.Object);

            // Act
            var response = await client.GetCampaignAttachmentsAsync(campaignId);

            // Assert
            var model = Assert.IsAssignableFrom<List<Attachment>>(response);
        }

        [Fact]
        public async Task GetCampaigns_ReturnsACampaignListResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<List<Campaign>>(Constants.CampaignsContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<List<Campaign>>(mockRestResponse.Object);

            // Act
            var response = await client.GetCampaignsAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<Campaign>>(response);
        }

        [Fact]
        public async Task GetCampaignsSentToAddressBook_ReturnsACampaignListResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<List<Campaign>>(Constants.CampaignsSentToAddressBookContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<List<Campaign>>(mockRestResponse.Object);
            var addressBookId = TestFactory.GetAddressBookId();

            // Act
            var response = await client.GetCampaignsSentToAddressBookAsync(addressBookId);

            // Assert
            var model = Assert.IsAssignableFrom<List<Campaign>>(response);
        }

        [Fact]
        public async Task GetCampaignsSentToSegment_ReturnsACampaignListResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<List<Campaign>>(Constants.CampaignsSentToSegmentContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<List<Campaign>>(mockRestResponse.Object);
            var segmentId = TestFactory.GetSegmentId();

            // Act
            var response = await client.GetCampaignsSentToSegmentAsync(segmentId);

            // Assert
            var model = Assert.IsAssignableFrom<List<Campaign>>(response);
        }

        [Fact]
        public async Task GetCampaign_ReturnsACampaignResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<Campaign>(Constants.CampaignContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<Campaign>(mockRestResponse.Object);
            var campaignId = TestFactory.GetCampaignId();

            // Act
            var response = await client.GetCampaignAsync(campaignId);

            // Assert
            var model = Assert.IsAssignableFrom<Campaign>(response);
        }

        [Fact]
        public async Task GetCampaignWithDetails_ReturnsACampaignWithDetailsResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<Campaign>(Constants.CampaignDetailsContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<Campaign>(mockRestResponse.Object);
            var campaignId = TestFactory.GetCampaignId();

            // Act
            var response = await client.GetCampaignWithDetailsAsync(campaignId);

            // Assert
            var model = Assert.IsAssignableFrom<Campaign>(response);
        }

        [Fact]
        public async Task GetCampaignSummary_ReturnsACampaignSummaryResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<CampaignSummary>(Constants.CampaignSummaryContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<CampaignSummary>(mockRestResponse.Object);
            var campaignId = TestFactory.GetCampaignId();

            // Act
            var response = await client.GetCampaignSummaryAsync(campaignId);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSummary>(response);
        }
    }
}

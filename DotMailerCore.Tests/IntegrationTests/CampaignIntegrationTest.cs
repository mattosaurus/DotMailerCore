using DotMailerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotMailerCore.Tests.IntegrationTests
{
    public class CampaignIntegrationTest
    {
        [Fact]
        public async Task CreateCampaign_ReturnsACampaignResponse()
        {
            // Arrange
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
            var campaignId = TestFactory.GetCampaignId();

            // Act
            await client.DeleteCampaignAsync(campaignId);
        }

        [Fact]
        public async Task GetCampaignSendStatus_ReturnsACampaignSendStatusResponse()
        {
            // Arrange
            var client = TestFactory.CreateDotMailerCoreClient();
            var campaignSendId = TestFactory.GetCampaignSendId();

            // Act
            var response = await client.GetCampaignSendStatusAsync(campaignSendId);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSend>(response);
        }

        [Fact]
        public async Task GetCampaigns_ReturnsACampaignListResponse()
        {
            // Arrange
            var client = TestFactory.CreateDotMailerCoreClient();

            // Act
            var response = await client.GetCampaignsAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<Campaign>>(response);
        }

        [Fact]
        public async Task GetCampaignsSentToAddressBook_ReturnsACampaignListResponse()
        {
            // Arrange
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
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
            var client = TestFactory.CreateDotMailerCoreClient();
            var campaignId = TestFactory.GetCampaignId();

            // Act
            var response = await client.GetCampaignSummaryAsync(campaignId);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSummary>(response);
        }
    }
}

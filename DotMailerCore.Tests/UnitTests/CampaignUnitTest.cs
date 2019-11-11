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
            var client = TestFactory.GetClient();
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
            var client = TestFactory.GetClient();
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
            var client = TestFactory.GetClient();
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
            var client = TestFactory.GetClient();
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
            var client = TestFactory.GetClient();
            var campaignId = TestFactory.GetCampaignId();

            // Act
            await client.DeleteCampaignAsync(campaignId);
        }



        [Fact]
        public async Task SendCampaign_ReturnsACampaignSendResponse()
        {
            // Arrange
            var campaignSend = TestFactory.GetCampaignSend();
            var mockClient = new Mock<IDotMailerCoreClient>();
            mockClient.Setup(client => client.SendCampaignAsync(campaignSend)).Returns(Task.FromResult(TestFactory.GetCampaignSend()));

            // Act
            var response = await mockClient.Object.SendCampaignAsync(campaignSend);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSend>(response);
        }

        [Fact]
        public async Task SendTimeOptimisedCampaign_ReturnsACampaignSendResponse()
        {
            // Arrange
            var campaignSend = TestFactory.GetCampaignSend();
            var mockClient = new Mock<IDotMailerCoreClient>();
            mockClient.Setup(client => client.SendTimeOptimisedCampaignAsync(campaignSend)).Returns(Task.FromResult(TestFactory.GetCampaignSend()));

            // Act
            var response = await mockClient.Object.SendTimeOptimisedCampaignAsync(campaignSend);

            // Assert
            var model = Assert.IsAssignableFrom<CampaignSend>(response);
        }

        [Fact]
        public async Task GetCampaignSendStatus_ReturnsACampaignSendStatusResponse()
        {
            // Arrange
            var client = TestFactory.GetClient();
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
            var mockClient = new Mock<IDotMailerCoreClient>();
            mockClient.Setup(client => client.AddCampaignAttachmentAsync(campaignId, attatchment)).Returns(Task.FromResult(TestFactory.GetCampaignAttatchment()));

            // Act
            var response = await mockClient.Object.AddCampaignAttachmentAsync(campaignId, attatchment);

            // Assert
            var model = Assert.IsAssignableFrom<Attatchment>(response);
        }

        [Fact]
        public async Task RemoveCampaignAttachment()
        {
            // Arrange
            var campaignId = TestFactory.GetCampaignId();
            var campaignAttatchmentId = TestFactory.GetCampaignAttatchmentId();
            var mockClient = new Mock<IDotMailerCoreClient>();
            mockClient.Setup(client => client.RemoveCampaignAttachmentAsync(campaignId, campaignAttatchmentId)).Returns(Task.CompletedTask);

            // Act
            await mockClient.Object.RemoveCampaignAttachmentAsync(campaignId, campaignAttatchmentId);
        }
    }
}

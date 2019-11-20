using DotMailerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotMailerCore.Tests.IntegrationTests
{
    public class AccountIntegrationTest
    {
        [Fact]
        public async Task GetAccountInformation_ReturnsAnAccountResponse()
        {
            // Arrange
            var client = TestFactory.CreateDotMailerCoreClient();

            // Act
            var baseResponse = await client.GetAccountInformationAsync();

            // Assert
            var model = Assert.IsAssignableFrom<Account>(baseResponse);
        }

        [Fact]
        public async Task EmptyRecycleBin()
        {
            // Arrange
            var client = TestFactory.CreateDotMailerCoreClient();

            // Act
            await client.EmptyRecycleBinAsync();
        }
    }
}

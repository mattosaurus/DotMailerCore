using DotMailerCore.Models;
using System.Threading.Tasks;
using Xunit;

namespace DotMailerCore.Tests.UnitTests
{
    public class AccountUnitTest
    {
        [Fact]
        public async Task GetAccountInformation_ReturnsAnAccountResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<Account>(Constants.AccountInformationContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<Account>(mockRestResponse.Object);

            // Act
            var baseResponse = await client.GetAccountInformationAsync();

            // Assert
            var model = Assert.IsAssignableFrom<Account>(baseResponse);
        }

        [Fact]
        public async Task EmptyRecycleBin()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse();
            var client = TestFactory.CreateDotMailerCoreClientWithResponse(mockRestResponse.Object);

            // Act
            await client.EmptyRecycleBinAsync();
        }
    }
}

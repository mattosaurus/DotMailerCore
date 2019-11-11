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
            var client = TestFactory.GetClient();

            // Act
            var response = await client.GetAccountInformationAsync();

            // Assert
            var model = Assert.IsAssignableFrom<Account>(response);
        }

        [Fact]
        public async Task EmptyRecycleBin()
        {
            // Arrange
            var client = TestFactory.GetClient();

            // Act
            await client.EmptyRecycleBinAsync();
        }
    }
}

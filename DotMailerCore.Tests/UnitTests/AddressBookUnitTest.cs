using DotMailerCore.Models;
using DotMailerCore.Models.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DotMailerCore.Tests.UnitTests
{
    public class AddressBookUnitTest
    {
        [Fact]
        public async Task CreateAddressBook_ReturnsAnAddressBookResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<AddressBook>(Constants.AddressBookCreateContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<AddressBook>(mockRestResponse.Object);
            var addressBook = TestFactory.GetAddressBook();

            // Act
            var response = await client.CreateAddressBookAsync(addressBook);

            // Assert
            var model = Assert.IsAssignableFrom<AddressBook>(response);
        }

        [Fact]
        public async Task DeleteAddressBook()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse();
            var client = TestFactory.CreateDotMailerCoreClientWithResponse(mockRestResponse.Object);
            var addressBookId = TestFactory.GetAddressBookId();

            // Act
            await client.DeleteAddressBookAsync(addressBookId);
        }

        [Fact]
        public async Task UpdateAddressBook_ReturnsAnAddressBookResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<AddressBook>(Constants.AddressBookUpdateContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<AddressBook>(mockRestResponse.Object);
            var addressBook = TestFactory.GetAddressBook();

            // Act
            var response = await client.UpdateAddressBookAsync(addressBook);

            // Assert
            var model = Assert.IsAssignableFrom<AddressBook>(response);
            Equals(model.Id, addressBook.Id);
        }

        [Fact]
        public async Task GetAddressBook_ReturnsAnAddressBookResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<AddressBook>(Constants.AddressBookContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<AddressBook>(mockRestResponse.Object);
            var id = TestFactory.GetAddressBookId();

            // Act
            var response = await client.GetAddressBookAsync(id);

            // Assert
            var model = Assert.IsAssignableFrom<AddressBook>(response);
            Equals(model.Id, id);
        }

        [Fact]
        public async Task GetAddressBooks_ReturnsAnAddressBooksResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<List<AddressBook>>(Constants.AddressBooksContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<List<AddressBook>>(mockRestResponse.Object);

            // Act
            var response = await client.GetAddressBooksAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<AddressBook>>(response);
        }

        [Fact]
        public async Task GetPrivateAddressBooks_ReturnsAPrivateAddressBooksResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<List<AddressBook>>(Constants.AddressBooksPrivateContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<List<AddressBook>>(mockRestResponse.Object);

            // Act
            var response = await client.GetPrivateAddressBooksAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<AddressBook>>(response);
            Assert.True(model.Where(x => x.Visibility == AddressBookVisibility.Private).Count() == model.Count());
        }

        [Fact]
        public async Task GetPublicAddressBooks_ReturnsAPublicAddressBooksResponse()
        {
            // Arrange
            var mockRestResponse = TestFactory.CreateMockRestResponse<List<AddressBook>>(Constants.AddressBooksPublicContent);
            var client = TestFactory.CreateDotMailerCoreClientWithResponse<List<AddressBook>>(mockRestResponse.Object);

            // Act
            var response = await client.GetPublicAddressBooksAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<AddressBook>>(response);
            Assert.True(model.Where(x => x.Visibility == AddressBookVisibility.Public).Count() == model.Count());
        }
    }
}

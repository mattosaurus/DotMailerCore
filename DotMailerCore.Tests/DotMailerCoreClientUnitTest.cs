using DotMailerCore.Models;
using DotMailerCore.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DotMailerCore.Tests
{
    public class DotMailerCoreClientUnitTest
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

        [Fact]
        public async Task CreateAddressBook_ReturnsAnAddressBookResponse()
        {
            // Arrange
            var client = TestFactory.GetClient();
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
            var client = TestFactory.GetClient();
            var addressBookId = TestFactory.GetAddressBookId();

            // Act
            await client.DeleteAddressBookAsync(addressBookId);
        }

        [Fact]
        public async Task UpdateAddressBook_ReturnsAnAddressBookResponse()
        {
            // Arrange
            var client = TestFactory.GetClient();
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
            var client = TestFactory.GetClient();
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
            var client = TestFactory.GetClient();

            // Act
            var response = await client.GetAddressBooksAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<AddressBook>>(response);
        }

        [Fact]
        public async Task GetPrivateAddressBooks_ReturnsAPrivateAddressBooksResponse()
        {
            // Arrange
            var client = TestFactory.GetClient();

            // Act
            var response = await client.GetPrivateAddressBooksAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<AddressBook>>(response);
            Assert.True(model.Where(x => x.Visibility == AddressBookVisibility.Private).Count() == model.Count());
        }

        [Fact]
        public async Task GetPrivateAddressBooks_ReturnsAPublicAddressBooksResponse()
        {
            // Arrange
            var client = TestFactory.GetClient();

            // Act
            var response = await client.GetPublicAddressBooksAsync();

            // Assert
            var model = Assert.IsAssignableFrom<List<AddressBook>>(response);
            Assert.True(model.Where(x => x.Visibility == AddressBookVisibility.Public).Count() == model.Count());
        }
    }
}

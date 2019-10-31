using DotMailerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotMailerCore.Clients
{
    public interface IDotMailerCoreClient
    {
        Task<Account> GetAccountInformationAsync();

        Task EmptyRecycleBinAsync();

        Task<AddressBook> CreateAddressBookAsync(AddressBook addressBook);

        Task DeleteAddressBookAsync(int id);

        Task<AddressBook> UpdateAddressBookAsync(AddressBook addressBook);

        Task<AddressBook> GetAddressBookAsync(int id);

        Task<List<AddressBook>> GetAddressBooksAsync(int select, int skip);

        Task<List<AddressBook>> GetPrivateAddressBooksAsync(int select, int skip);

        Task<List<AddressBook>> GetPublicAddressBooksAsync(int select, int skip);
    }
}

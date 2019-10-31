using ApiBaseClient;
using DotMailerCore.Clients;
using DotMailerCore.Helpers;
using DotMailerCore.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotMailerCore
{
    public class DotMailerCoreClient : BaseClient, IDotMailerCoreClient
    {
        public DotMailerCoreClient(ICacheService cache, IDeserializer serializer, ILoggerFactory loggerFactory, IOptions<DotMailerCoreOptions> options)
            : base(cache, serializer, loggerFactory, options.Value.BaseUrl, options.Value.Authenticator) { }

        public DotMailerCoreClient(IOptions<DotMailerCoreOptions> options)
            : base(options.Value.BaseUrl, options.Value.Authenticator) { }

        #region Account

        /// <summary>
        /// Gets a summary of information about the current status of the account.
        /// </summary>
        public async Task<Account> GetAccountInformationAsync()
        {
            var request = new RestRequest("account-info");
            return await MakeRequestAsync<Account>(request);
        }

        /// <summary>
        /// Permanently deletes everything in the recycle bin.
        /// </summary>
        public async Task EmptyRecycleBinAsync()
        {
            var request = new RestRequest("accounts/empty-recycle-bin/", Method.POST);
            await MakeRequestAsync(request);
        }

        #endregion

        #region Address

        /// <summary>
        /// Creates an address book.
        /// </summary>
        public async Task<AddressBook> CreateAddressBookAsync(AddressBook addressBook)
        {
            var request = new RestRequest("/address-books", Method.POST);
            request.AddJsonBody(addressBook);

            return await MakeRequestAsync<AddressBook>(request);
        }

        /// <summary>
        /// Deletes an address book by ID.
        /// </summary>
        public async Task DeleteAddressBookAsync(int id)
        {
            var request = new RestRequest("/address-books/{id}", Method.DELETE);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            await MakeRequestAsync(request);
        }

        /// <summary>
        /// Updates an address book by ID.
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public async Task<AddressBook> UpdateAddressBookAsync(AddressBook addressBook)
        {
            var request = new RestRequest("/address-books/{addressBook.Id}", Method.PUT);
            request.AddJsonBody(addressBook);

            return await MakeRequestAsync<AddressBook>(request);
        }

        /// <summary>
        /// Gets an address book by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AddressBook> GetAddressBookAsync(int id)
        {
            var request = new RestRequest("/address-books/{id}");

            return await MakeRequestAsync<AddressBook>(request);
        }

        /// <summary>
        /// Gets all address books.
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<AddressBook>> GetAddressBooksAsync(int select, int skip)
        {
            var request = new RestRequest("/address-books/");
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<AddressBook>>(request);
        }

        /// <summary>
        /// Gets all private address books.
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<AddressBook>> GetPrivateAddressBooksAsync(int select, int skip)
        {
            var request = new RestRequest("/address-books/private");
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<AddressBook>>(request);
        }

        /// <summary>
        /// Gets all public address books.
        /// </summary>
        /// <param name="select">The select parameter requires a number between 1 and 1000 (0 is not a valid number). You may only select a maximum of 1000 results in a single request. This parameter goes within the URL.</param>
        /// <param name="skip">The skip parameter should be used in tandem with the select parameter when wanting to iterate through a whole data set. If you want to select the next 1000 records you should set the select parameter to 1000 and the skip parameter to 1000, which will return records 1001 to 2000. You should continue to do this until 0 records are returned to retrieve the whole data set. This parameter goes within the URL.</param>
        /// <returns></returns>
        public async Task<List<AddressBook>> GetPublicAddressBooksAsync(int select, int skip)
        {
            var request = new RestRequest("/address-books/public");
            request.AddParameter("select", select, ParameterType.QueryString);
            request.AddParameter("skip", skip, ParameterType.QueryString);

            return await MakeRequestAsync<List<AddressBook>>(request);
        }

        #endregion
    }
}

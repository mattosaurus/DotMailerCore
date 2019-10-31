using DotMailerCore.Clients;
using DotMailerCore.Helpers;
using DotMailerCore.Models;
using DotMailerCore.Models.Types;
using Microsoft.Extensions.Options;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Tests
{
    public class TestFactory
    {
        public static DotMailerCoreClient GetClient()
        {
            IOptions<DotMailerCoreOptions> options = Options.Create<DotMailerCoreOptions>(new DotMailerCoreOptions()
                {
                    BaseUrl = "https://api.dotmailer.com/v2/",
                    Authenticator = new HttpBasicAuthenticator("demo@apiconnector.com", "demo")
                }
            );

            DotMailerCoreClient dotMailerCoreClient = new DotMailerCoreClient(options);

            return dotMailerCoreClient;
        }

        public static AddressBook GetAddressBook()
        {
            return new AddressBook()
            {
                Id = 1,
                Name = "My Address Book",
                Visibility = AddressBookVisibility.Public
            };
        }

        public static int GetAddressBookId()
        {
            return 1;
        }
    }
}

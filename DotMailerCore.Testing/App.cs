using DotMailerCore.Clients;
using DotMailerCore.Models;
using DotMailerCore.Models.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotMailerCore.Testing
{
    public class App
    {
        private readonly IDotMailerCoreClient _dotMailerCoreClient;
        private readonly ILogger<DotMailerCoreClient> _logger;

        public App(ILogger<DotMailerCoreClient> logger, IDotMailerCoreClient dotMailerCoreClient)
        {
            _dotMailerCoreClient = dotMailerCoreClient;
            _logger = logger;
        }

        public async Task Run()
        {
            //_logger.LogInformation("Getting account information");
            //Account apiAccount = await _dotMailerCoreClient.GetAccountInformationAsync();

            //_logger.LogInformation("Emptying recycle bin");
            //await _dotMailerCoreClient.EmptyRecycleBinAsync();

            //AddressBook addressBookRequest = new AddressBook()
            //{
            //    Name = "My Address Book",
            //    Visibility = AddressBookVisibility.Public
            //};

            //_logger.LogInformation("Creating address book");
            //AddressBook addressBookResponse = await _dotMailerCoreClient.CreateAddressBookAsync(addressBookRequest);

            //_logger.LogInformation("deleting address book");
            //await _dotMailerCoreClient.DeleteAddressBookAsync(1);

            CampaignSend campaignSend = new CampaignSend()
            {
                Id = new Guid("e8224c2b-a670-461e-b060-4ec776e9e7c2"),
                CampaignId = 1,
                SendDate = DateTime.Parse("2015-10-31T00:00:00"),
                SplitTestOptions = new SplitTestOptions()
                {
                    TestMetric = TestMetric.Opens,
                    TestPercentage = 50,
                    TestPeriodHours = 5
                }
            };
            await _dotMailerCoreClient.SendCampaignAsync(campaignSend);
        }
    }
}

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

        public static Campaign GetCampaign()
        {
            return new Campaign()
            {
                Id = 6302600,
                Name = "New product promotion 2",
                Subject = "New product!",
                FromName = "Company name",
                FromAddress = new CampaignFromAddress()
                {
                    Id = 133618,
                    Email = "products@mycompany.com"
                },
                HtmlContent = @"<!-- Easy Editor -->
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""ee_resizable ee_mobiletemplate"" data-dmtmp=""true"">
  <tbody>
    <tr>
      <td align=""center"" bgcolor=""#ffffff"" cellpadding=""0"" cellspacing=""0"">
        <table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""eem_mainouterzone"">
          <tbody>
            <tr>
              <td bgcolor=""#ffffff"" class=""ee_dropzone"" style=""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;"" align=""left"">
                <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;"" class=""ee_element"" bgcolor=""#ffffff"">
                  <tbody>
                    <tr>
                      <td align=""left"" style=""padding: 0px; width: 600px;"" class=""""><div class=""ee_editable""><font style=""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;""><a href=""http://$UNSUB$"" style=""color: black;""> Unsubscribe from this newsletter</a></font> </div></td>
                    </tr>
                  </tbody>
                </table>
              </td>
            </tr>
          </tbody>
        </table>
      </td>
    </tr>
  </tbody>
</table>",
                PlainTextContent = "Want to unsubscribe? $UNSUB$",
                ReplyAction = CampaignReplyAction.Unset,
                ReplyToAddress = "",
                IsSplitTest = false,
                Status = CampaignStatus.Unsent
            };
        }

        public static SplitTestCampaign GetSplitTestCampaign()
        {
            return new SplitTestCampaign()
            {
                Id = 1,
                Name = "Split Test Campaign",
                Subjects = new List<string>()
                {
                    "My subject variation A",
                    "My subject variation B",
                    "My subject variation C"
                },
                FromNames = new List<string>()
                {
                    "My name variation A",
                    "My name variation B",
                    "My name variation C"
                },
                FromAddresses = new List<CampaignFromAddress>()
                {
                    new CampaignFromAddress() {
                        Id = 1,
                        Email = "hello@my-domain.com"
                    },
                    new CampaignFromAddress() {
                        Id = 2,
                        Email = "hello@my-other-domain.com"
                    },
                    new CampaignFromAddress() {
                        Id = 3,
                        Email = "hello@my-experimental-domain.com"
                    }
                },
                HtmlContents = new List<string>()
                {
                    @"<!-- Easy Editor -->
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""ee_resizable ee_mobiletemplate"" data-dmtmp=""true"">
  <tbody>
    <tr>
      <td align=""center"" bgcolor=""#ffffff"" cellpadding=""0"" cellspacing=""0"">
        <table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""eem_mainouterzone"">
          <tbody>
            <tr>
              <td bgcolor=""#ffffff"" class=""ee_dropzone"" style=""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;"" align=""left"">
                <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;"" class=""ee_element"" bgcolor=""#ffffff"">
                  <tbody>
                    <tr>
                      <td align=""left"" style=""padding: 0px; width: 600px;"" class=""""><div class=""ee_editable""><font style=""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;""><a href=""http://$UNSUB$"" style=""color: black;""> Want to unsubscribe?</a></font> </div></td>
                    </tr>
                  </tbody>
                </table>
              </td>
            </tr>
          </tbody>
        </table>
      </td>
    </tr>
  </tbody>
</table>",
                    @"<!-- Easy Editor -->
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""ee_resizable ee_mobiletemplate"" data-dmtmp=""true"">
  <tbody>
    <tr>
      <td align=""center"" bgcolor=""#ffffff"" cellpadding=""0"" cellspacing=""0"">
        <table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""eem_mainouterzone"">
          <tbody>
            <tr>
              <td bgcolor=""#ffffff"" class=""ee_dropzone"" style=""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;"" align=""left"">
                <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;"" class=""ee_element"" bgcolor=""#ffffff"">
                  <tbody>
                    <tr>
                      <td align=""left"" style=""padding: 0px; width: 600px;"" class=""""><div class=""ee_editable""><font style=""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;""><a href=""http://$UNSUB$"" style=""color: black;""> Don't want to hear from us?</a></font> </div></td>
                    </tr>
                  </tbody>
                </table>
              </td>
            </tr>
          </tbody>
        </table>
      </td>
    </tr>
  </tbody>
</table>",
                    @"<!-- Easy Editor -->
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""ee_resizable ee_mobiletemplate"" data-dmtmp=""true"">
  <tbody>
    <tr>
      <td align=""center"" bgcolor=""#ffffff"" cellpadding=""0"" cellspacing=""0"">
        <table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: auto;"" class=""eem_mainouterzone"">
          <tbody>
            <tr>
              <td bgcolor=""#ffffff"" class=""ee_dropzone"" style=""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;"" align=""left"">
                <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;"" class=""ee_element"" bgcolor=""#ffffff"">
                  <tbody>
                    <tr>
                      <td align=""left"" style=""padding: 0px; width: 600px;"" class=""""><div class=""ee_editable""><font style=""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;""><a href=""http://$UNSUB$"" style=""color: black;""> Remove me from this list</a></font> </div></td>
                    </tr>
                  </tbody>
                </table>
              </td>
            </tr>
          </tbody>
        </table>
      </td>
    </tr>
  </tbody>
</table>",
                },
                PlainTextContents = new List<string>()
                {
                    "Want to unsubscribe? $UNSUB$",
                    "Don't want to hear from us? $UNSUB$",
                    "Remove me from this list $UNSUB$"
                },
                ReplyAction = CampaignReplyAction.Unset,
                ReplyToAddress = "",
                Status = CampaignStatus.Unsent
            };
        }

        public static int GetCampaignId()
        {
            return 1;
        }

        public static CampaignSend GetCampaignSend()
        {
            return new CampaignSend()
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
        }

        public static Guid GetCampaignSendId()
        {
            return new Guid("e8224c2b-a670-461e-b060-4ec776e9e7c2");
        }

        public static Attatchment GetCampaignAttatchment()
        {
            return new Attatchment()
            {
                Id = 3,
                Name = "Directions to Conference.pdf",
                FileName = @"/cmpdoc/5/0/7/4/7/files/3_directions-to-conference.pdf",
                FileSize = 24225,
                DateCreated = DateTime.Parse("2015-11-24T11:48:38.397"),
                DateModified = DateTime.Parse("2015-11-24T11:48:38.397")
            };
        }

        public static int GetCampaignAttatchmentId()
        {
            return 2;
        }
    }
}

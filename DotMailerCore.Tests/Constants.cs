using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Tests
{
    public static class Constants
    {
        public const string AccountInformationContent = @"{
    ""id"": 1,
    ""properties"": [
        {
            ""name"": ""AvailableEmailSendsCredits"",
            ""type"": ""Int"",
            ""value"": ""153""
        },
        {
            ""name"": ""AvailableSmsSendsCredits"",
            ""type"": ""Int"",
            ""value"": ""276""
        },
        {
            ""name"": ""ListManagedUsers"",
            ""type"": ""String"",
            ""value"": ""subaccount@example.com, subuser@example.com""
        },
        {
            ""name"": ""Name"",
            ""type"": ""String"",
            ""value"": ""Demo""
        },
        {
            ""name"": ""MainMobilePhoneNumber"",
            ""type"": ""String"",
            ""value"": ""01818181818""
        },
        {
            ""name"": ""MainEmail"",
            ""type"": ""String"",
            ""value"": ""demo@apiconnector.com""
        },
        {
            ""name"": ""ApiCallsInLastHour"",
            ""type"": ""Int"",
            ""value"": ""15""
        },
        {
            ""name"": ""ApiCallsRemaining"",
            ""type"": ""Int"",
            ""value"": ""1985""
        },
        {
            ""name"": ""ApiEndpoint"",
            ""type"": ""String"",
            ""value"": ""https://r1-api.dotmailer.com""
        }
    ]
}";

        public const string AddressBookCreateContent = @"{
    ""id"": 1,
    ""name"": ""My Address Book"",
    ""visibility"": ""Public"",
    ""contacts"": 0
}";

        public const string AddressBookUpdateContent = @"{
  ""id"": 1,
  ""name"": ""My Updated Address Book"",
  ""visibility"": ""Private"",
  ""contacts"": 0
}";

        public const string AddressBookContent = @"{
    ""id"": 2,
    ""name"": ""Address book 2"",
    ""visibility"": ""Private"",
    ""contacts"": 5
}";

        public const string AddressBooksContent = @"[
  {
    ""id"": 1,
    ""name"": ""Address book 1"",
    ""visibility"": ""Private"",
    ""contacts"": 5
  },
  {
    ""id"": 2,
    ""name"": ""Address book 2"",
    ""visibility"": ""Public"",
    ""contacts"": 7
  },
  {
    ""id"": 3,
    ""name"": ""Address book 3"",
    ""visibility"": ""Private"",
    ""contacts"": 7
  },
  {
    ""id"": 4,
    ""name"": ""Address book 4"",
    ""visibility"": ""Public"",
    ""contacts"": 6
  }
]";

        public const string AddressBooksPrivateContent = @"[
  {
    ""id"": 2,
    ""name"": ""Address book 2"",
    ""visibility"": ""Private"",
    ""contacts"": 5
  },
  {
    ""id"": 3,
    ""name"": ""Address book 3"",
    ""visibility"": ""Private"",
    ""contacts"": 7
  }
]";

        public const string AddressBooksPublicContent = @"[
  {
    ""id"": 1,
    ""name"": ""Address book 1"",
    ""visibility"": ""Public"",
    ""contacts"": 7
  },
  {
    ""id"": 4,
    ""name"": ""Address book 4"",
    ""visibility"": ""Public"",
    ""contacts"": 6
  }
]";

        public const string CampaignCreateContent = @"{
  ""id"": 6302600,
  ""name"": ""New product promotion 2"",
  ""subject"": ""New product!"",
  ""fromName"": ""Company name"",
  ""fromAddress"": {
    ""id"": 133618,
    ""email"": ""products @mycompany.com""
  },
  ""htmlContent"": ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n<tbody>\r\n<tr>\r\n<td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Unsubscribe from this newsletter</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>"",
  ""plainTextContent"": ""\r\n\r\n---\r\nWant to unsubscribe? $UNSUB$"",
  ""replyAction"": ""Unset"",
  ""replyToAddress"": """",
  ""isSplitTest"": false,
  ""status"": ""Unsent""
}";

        public const string CampaignSplitTestCreateContent = @"{
  ""id"": 1,
  ""name"": ""Split Test Campaign"",
  ""subjects"": [
    ""My subject variation A"",
    ""My subject variation B"",
    ""My subject variation C""
],
  ""fromNames"": [
    ""My name variation A"",
    ""My name variation B"",
    ""My name variation C""
  ],
  ""fromAddresses"": [
    {
      ""id"": 1,
      ""email"": ""hello@my-domain.com""
    },
    {
      ""id"": 2,
      ""email"": ""hello@my-other-domain.com""
    },
    {
      ""id"": 3,
      ""email"": ""hello@my-experimental-domain.com""
    }
  ],
  ""htmlContents"": [
    ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n  <tbody>\r\n    <tr>\r\n      <td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Unsubscribe from this newsletter</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>"",
    ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n  <tbody>\r\n    <tr>\r\n      <td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Don't want to hear from us?</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>"",
    ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n  <tbody>\r\n    <tr>\r\n      <td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Remove me from this list</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>""
  ],
  ""plainTextContents"": [
    ""\r\n\r\n---\r\nWant to unsubscribe? $UNSUB$"",
    ""\r\n\r\n---\r\nDon't want to hear from us? $UNSUB$"",
    ""\r\n\r\n---\r\nRemove me from this list $UNSUB$""
  ],
  ""replyAction"": ""Unset"",
  ""replyToAddress"": """",
  ""status"": ""Unsent"",}";

        public const string CampaignUpdateContent = @"{
  ""id"": 1,
  ""name"": ""New product promotion 2"",
  ""subject"": ""Check out our newest product!"",
  ""fromName"": ""Company name"",
  ""fromAddress"": {
    ""id"": 133618,
    ""email"": ""products@mycompany.com""
  },
  ""htmlContent"": ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n  <tbody>\r\n    <tr>\r\n      <td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Unsubscribe from this newsletter</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>"",
  ""plainTextContent"": ""\r\n\r\n---\r\nWant to unsubscribe? $UNSUB$"",
  ""replyAction"": ""Unset"",
  ""replyToAddress"": """",
  ""isSplitTest"": false,
  ""status"": ""Unsent""
}";

        public const string CampaignCopyContent = @"{
  ""id"": 6303192,
  ""name"": ""Copy of New product promotion 2"",
  ""subject"": ""New product!"",
  ""fromName"": ""Company name"",
  ""fromAddress"": {
    ""id"": 133618,
    ""email"": ""products@mycompany.com""
  },
  ""htmlContent"": ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n  <tbody>\r\n    <tr>\r\n      <td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Unsubscribe from this newsletter</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>"",
  ""plainTextContent"": ""\r\n\r\n---\r\nWant to unsubscribe? $UNSUB$"",
  ""replyAction"": ""Unset"",
  ""replyToAddress"": """",
  ""isSplitTest"": false,
  ""status"": ""Unsent""
}";

        public const string CampaignSendContent = @"{
  ""id"": ""e8224c2b-a670-461e-b060-4ec776e9e7c2"",
  ""campaignId"": 1,
  ""addressBookIds"": null,
  ""contactIds"": [1],
  ""sendDate"": ""2015-10-31T00:00:00"",
  ""splitTestOptions"": {
    ""TestMetric"": ""Opens"",
    ""TestPercentage"": 50,
    ""TestPeriodHours"": 5
  },
  ""status"": ""Sending""
}";

        public const string CampaignSendTimeOptimisedContent = @"{
  ""id"": ""f415abb9-e98a-4f58-b136-795e69d6d2a0"",
  ""campaignId"": 1,
  ""addressBookIds"": null,
  ""contactIds"": null,
  ""sendDate"": ""2015-10-22T11:08:46+01:00"",
  ""splitTestOptions"": null,
  ""status"": ""NotSent""
}";

        public const string CampaignSendStatusContent = @"{
  ""id"": ""842d81e8-c619-457f-bb77-ab6c4a17da39"",
  ""campaignId"": 1,
  ""addressBookIds"": null,
  ""contactIds"": null,
  ""sendDate"": ""2015-09-11T11:06:47.7644899+01:00"",
  ""splitTestOptions"": null,
  ""status"": ""Sent""
}";

        public const string CampaignAddCampaignAttatchmentContent = @"{
  ""id"": 3,
  ""name"": ""Directions to Conference.pdf"",
  ""fileName"": ""/cmpdoc/5/0/7/4/7/files/3_directions-to-conference.pdf"",
  ""fileSize"": 24225,
  ""dateCreated"": ""2015-11-24T11:48:38.397"",
  ""dateModified"": ""2015-11-24T11:48:38.397""
}";

        public const string CampaignCampaignAttatchmentsContent = @"[
  {
    ""id"": 2,
    ""name"": ""Conference schedule.pdf"",
    ""fileName"": ""/cmpdoc/5/0/7/4/7/files/1_conference-schedule.pdf"",
    ""fileSize"": 24225,
    ""dateCreated"": ""2015-11-24T11:48:32.817"",
    ""dateModified"": ""2015-11-24T11:48:32.817""
  },
  {
    ""id"": 3,
    ""name"": ""Directions to Conference.pdf"",
    ""fileName"": ""/cmpdoc/5/0/7/4/7/files/2_directions-to-conference.pdf"",
    ""fileSize"": 24225,
    ""dateCreated"": ""2015-11-24T11:48:38.397"",
    ""dateModified"": ""2015-11-24T11:48:38.397""
  }
]";

        public const string CampaignsContent = @"[
  {
    ""id"": 2,
    ""name"": ""Financial update"",
    ""subject"": ""Financial update"",
    ""fromName"": ""Company name"",
    ""fromAddress"": {
      ""id"": 2,
      ""email"": ""demo@apiconnector.com""
    },
    ""htmlContent"": null,
    ""plainTextContent"": null,
    ""replyAction"": ""Unset"",
    ""replyToAddress"": null,
    ""isSplitTest"": false,
    ""status"": ""Unsent""
  },
  {
    ""id"": 4,
    ""name"": ""New product promotion"",
    ""subject"": ""New product!"",
    ""fromName"": ""Company name"",
    ""fromAddress"": {
      ""id"": 1,
      ""email"": ""demo@apiconnector.com""
    },
    ""htmlContent"": null,
    ""plainTextContent"": null,
    ""replyAction"": ""WebMailForward"",
    ""replyToAddress"": ""demo@apiconnector.com"",
    ""isSplitTest"": false,
    ""status"": ""Sent""
  }
]";

        public const string CampaignsSentToAddressBookContent = @"[
  {
    ""id"": 1,
    ""name"": ""Monthly newsletter Dec 2015"",
    ""subject"": ""Monthly newsletter"",
    ""fromName"": ""Company name"",
    ""fromAddress"": {
      ""id"": 1,
      ""email"": ""demo@apiconnector.com""
    },
    ""htmlContent"": null,
    ""plainTextContent"": null,
    ""replyAction"": ""Unset"",
    ""replyToAddress"": null,
    ""isSplitTest"": false,
    ""status"": ""Sent""
  },
  {
    ""id"": 4,
    ""name"": ""New product promotion"",
    ""subject"": ""New product!"",
    ""fromName"": ""Company name"",
    ""fromAddress"": {
      ""id"": 1,
      ""email"": ""demo@apiconnector.com""
    },
    ""htmlContent"": null,
    ""plainTextContent"": null,
    ""replyAction"": ""WebMailForward"",
    ""replyToAddress"": ""demo@apiconnector.com"",
    ""isSplitTest"": false,
    ""status"": ""Sent""
  }
]";

        public const string CampaignsSentToSegmentContent = @"[
  {
    ""id"": 1,
    ""name"": ""Monthly newsletter Dec 2015"",
    ""subject"": ""Monthly newsletter"",
    ""fromName"": ""Company name"",
    ""fromAddress"": {
      ""id"": 1,
      ""email"": ""demo@apiconnector.com""
    },
    ""htmlContent"": null,
    ""plainTextContent"": null,
    ""replyAction"": ""Unset"",
    ""replyToAddress"": null,
    ""isSplitTest"": false,
    ""status"": ""Sent""
  },
  {
    ""id"": 4,
    ""name"": ""New product promotion"",
    ""subject"": ""New product!"",
    ""fromName"": ""Company name"",
    ""fromAddress"": {
      ""id"": 1,
      ""email"": ""demo@apiconnector.com""
    },
    ""htmlContent"": null,
    ""plainTextContent"": null,
    ""replyAction"": ""WebMailForward"",
    ""replyToAddress"": ""demo@apiconnector.com"",
    ""isSplitTest"": false,
    ""status"": ""Sent""
  }
]";

        public const string CampaignContent = @"{
  ""id"": 6302600,
  ""name"": ""New product promotion 2"",
  ""subject"": ""New product!"",
  ""fromName"": ""Company name"",
  ""fromAddress"": {
    ""id"": 133618,
    ""email"": ""products@mycompany.com""
  },
  ""htmlContent"": ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n  <tbody>\r\n    <tr>\r\n      <td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Unsubscribe from this newsletter</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>"",
  ""plainTextContent"": ""\r\n\r\n---\r\nWant to unsubscribe? $UNSUB$"",
  ""replyAction"": ""Unset"",
  ""replyToAddress"": """",
  ""isSplitTest"": false,
  ""status"": ""Unsent""
}";

        public const string CampaignDetailsContent = @"{
  ""id"": 1,
  ""name"": ""New product promotion 2"",
  ""subject"": ""New product!"",
  ""fromName"": ""Company name"",
  ""fromAddress"": {
    ""id"": 133618,
    ""email"": ""products@mycompany.com""
  },
  ""htmlContent"": ""\r\n<!-- Easy Editor -->\r\n<table width=\""100%\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""ee_resizable ee_mobiletemplate\"" data-dmtmp=\""true\"">\r\n  <tbody>\r\n    <tr>\r\n      <td align=\""center\"" bgcolor=\""#ffffff\"" cellpadding=\""0\"" cellspacing=\""0\"">\r\n        <table width=\""600\"" border=\""0\"" cellspacing=\""0\"" cellpadding=\""0\"" style=\""table-layout: auto;\"" class=\""eem_mainouterzone\"">\r\n          <tbody>\r\n            <tr>\r\n              <td bgcolor=\""#ffffff\"" class=\""ee_dropzone\"" style=\""padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;\"" align=\""left\"">\r\n                <table width=\""100%\"" cellpadding=\""0\"" cellspacing=\""0\"" style=\""width: 600px; background-color: rgb(255, 255, 255); table-layout: auto;\"" class=\""ee_element\"" bgcolor=\""#ffffff\"">\r\n                  <tbody>\r\n                    <tr>\r\n                      <td align=\""left\"" style=\""padding: 0px; width: 600px;\"" class=\""\""><div class=\""ee_editable\""><font style=\""font-family: 'trebuchet ms', verdana, arial, sans-serif; font-size: 13px;\""><a href=\""http://$UNSUB$\"" style=\""color: black;\""> Unsubscribe from this newsletter</a></font> </div></td>\r\n                    </tr>\r\n                  </tbody>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </tbody>\r\n        </table>\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>"",
  ""plainTextContent"": ""\r\n\r\n---\r\nWant to unsubscribe? $UNSUB$"",
  ""replyAction"": ""Unset"",
  ""replyToAddress"": """",
  ""isSplitTest"": true,
  ""status"": ""Unsent"",
  ""type"": ""Standard"",
  ""tags"": [
    {
      ""name"": ""Product""
    },
    {
      ""name"": ""Promotion""
    }
  ],
  ""splitTestOptions"": [
    ""Subject"",
    ""FromAddress"",
    ""FromName"",
    ""Html"",
    ""PlainText""
  ],
  ""sentDate"": ""2019-03-01T16:09:48.07""
}";

        public const string CampaignSummaryContent = @"{
  ""dateSent"": ""2013-01-02T00:00:00"",
  ""numUniqueOpens"": 3,
  ""numUniqueTextOpens"": 10,
  ""numTotalUniqueOpens"": 13,
  ""numOpens"": 4,
  ""numTextOpens"": 14,
  ""numTotalOpens"": 18,
  ""numClicks"": 1,
  ""numTextClicks"": 8,
  ""numTotalClicks"": 9,
  ""numPageViews"": 6,
  ""numTotalPageViews"": 33,
  ""numTextPageViews"": 27,
  ""numForwards"": 1,
  ""numTextForwards"": 8,
  ""numEstimatedForwards"": 6,
  ""numTextEstimatedForwards"": 27,
  ""numTotalEstimatedForwards"": 33,
  ""numReplies"": 2,
  ""numTextReplies"": 2,
  ""numTotalReplies"": 4,
  ""numHardBounces"": 1,
  ""numTextHardBounces"": 0,
  ""numTotalHardBounces"": 1,
  ""numSoftBounces"": 1,
  ""numTextSoftBounces"": 0,
  ""numTotalSoftBounces"": 1,
  ""numUnsubscribes"": 1,
  ""numTextUnsubscribes"": 2,
  ""numTotalUnsubscribes"": 3,
  ""numIspComplaints"": 1,
  ""numTextIspComplaints"": 0,
  ""numTotalIspComplaints"": 1,
  ""numMailBlocks"": 0,
  ""numTextMailBlocks"": 0,
  ""numTotalMailBlocks"": 0,
  ""numSent"": 6,
  ""numTextSent"": 12,
  ""numTotalSent"": 18,
  ""numRecipientsClicked"": 9,
  ""numDelivered"": 4,
  ""numTextDelivered"": 12,
  ""numTotalDelivered"": 16,
  ""percentageDelivered"": 0.8888888888888888,
  ""percentageUniqueOpens"": 0.8125,
  ""percentageOpens"": 1.125,
  ""percentageUnsubscribes"": 0.1875,
  ""percentageReplies"": 0.25,
  ""percentageHardBounces"": 0.05555555555555555,
  ""percentageSoftBounces"": 0.0625,
  ""percentageUsersClicked"": 0.5625,
  ""percentageClicksToOpens"": 0.5
}";
    }
}

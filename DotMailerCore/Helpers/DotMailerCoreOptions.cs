using ApiBaseClient.Helpers;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Helpers
{
    public class DotMailerCoreOptions
    {
        public string BaseUrl { get; set; } = "https://api.dotmailer.com/v2/";

        public IAuthenticator Authenticator { get; set; }

        public IEnumerable<string> ContentTypes { get; set; } = new List<string>()
                {
                    "application/json",
                    "text/json",
                    "text/x-json"
                };

        public IDeserializer Deserializer { get; set; } = new NewtonsoftJsonRestSerializer();
    }
}

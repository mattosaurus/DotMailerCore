using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Helpers
{
    public class DotMailerCoreOptions
    {
        public string BaseUrl { get; set; } = "https://api.dotmailer.com/v2/";

        public IAuthenticator Authenticator { get; set; }
    }
}

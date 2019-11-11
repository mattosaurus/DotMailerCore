using ApiBaseClient.Helpers;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiBaseClient
{
    public class BaseClient : RestSharp.RestClient, IBaseClient
    {
        protected ICacheService _cache;

        public BaseClient(string baseUrl, ICacheService cache, IDeserializer deserializer, IAuthenticator authenticator)
        {
            _cache = cache;
            AddHandler("application/json", () => deserializer);
            AddHandler("text/json", () => deserializer);
            AddHandler("text/x-json", () => deserializer);
            BaseUrl = new Uri(baseUrl);
            Authenticator = authenticator;
        }

        public BaseClient(string baseUrl, ICacheService cache, IDeserializer deserializer)
        {
            _cache = cache;
            AddHandler("application/json", () => deserializer);
            AddHandler("text/json", () => deserializer);
            AddHandler("text/x-json", () => deserializer);
            BaseUrl = new Uri(baseUrl);
        }

        public BaseClient(string baseUrl, IAuthenticator authenticator, IDeserializer deserializer)
        {
            AddHandler("application/json", () => deserializer);
            AddHandler("text/json", () => deserializer);
            AddHandler("text/x-json", () => deserializer);
            BaseUrl = new Uri(baseUrl);
            Authenticator = authenticator;
        }

        public BaseClient(string baseUrl, IAuthenticator authenticator)
        {
            NewtonsoftJsonRestSerializer jsonSerializer = new NewtonsoftJsonRestSerializer();

            AddHandler("application/json", () => jsonSerializer);
            AddHandler("text/json", () => jsonSerializer);
            AddHandler("text/x-json", () => jsonSerializer);
            BaseUrl = new Uri(baseUrl);
            Authenticator = authenticator;
        }

        public BaseClient(string baseUrl)
        {
            NewtonsoftJsonRestSerializer jsonSerializer = new NewtonsoftJsonRestSerializer();

            AddHandler("application/json", () => jsonSerializer);
            AddHandler("text/json", () => jsonSerializer);
            AddHandler("text/x-json", () => jsonSerializer);
            BaseUrl = new Uri(baseUrl);
        }

        private void ThrowException(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, the status code, and the parameters.
            string info = "Request to " + BaseUrl.AbsoluteUri + request.Resource + " failed with status code " + response.StatusCode + ", parameters: "
                + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            Exception exception;
            if (response != null && response.ErrorException != null)
            {
                exception = response.ErrorException;
            }
            else
            {
                exception = new Exception(info);
                info = string.Empty;
            }

            ApiException apiException = new ApiException(
                (int)response.StatusCode,
                exception.Message,
                info,
                exception
                );

            throw apiException;
        }

        private bool TimeoutCheck(IRestRequest request, IRestResponse response)
        {
            if (response.StatusCode == 0)
            {
                ThrowException(BaseUrl, request, response);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override IRestResponse Execute(IRestRequest request)
        {
            var response = base.Execute(request);

            TimeoutCheck(request, response);
            return response;
        }

        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            var response = base.Execute<T>(request);
            TimeoutCheck(request, response);
            return response;
        }

        public async override Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            var response = await base.ExecuteTaskAsync(request);
            TimeoutCheck(request, response);
            return response;
        }

        public async override Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            var response = await base.ExecuteTaskAsync<T>(request);
            TimeoutCheck(request, response);
            return response;
        }

        public T MakeRequest<T>(IRestRequest request) where T : new()
        {
            var response = Execute<T>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                ThrowException(BaseUrl, request, response);
                return default(T);
            }
        }

        public void MakeRequest(IRestRequest request)
        {
            var response = Execute(request);
            if (!response.IsSuccessful)
            {
                ThrowException(BaseUrl, request, response);
            }
        }

        public async Task<T> MakeRequestAsync<T>(IRestRequest request) where T : new()
        {
            var response = await ExecuteTaskAsync<T>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                ThrowException(BaseUrl, request, response);
                return default(T);
            }
        }

        public async Task MakeRequestAsync(IRestRequest request)
        {
            var response = await ExecuteTaskAsync(request);
            if (!response.IsSuccessful)
            {
                ThrowException(BaseUrl, request, response);
            }
        }

        public T MakeRequestFromCache<T>(IRestRequest request, string cacheKey, int cacheMinutes = 30) where T : class, new()
        {
            var item = _cache.Get<T>(cacheKey);
            if (item == null) //If the cache doesn't have the item
            {
                var response = Execute<T>(request); //Get the item from the API call
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _cache.Set(cacheKey, response.Data, cacheMinutes); //Set that item into the cache so we can get it next time
                    item = response.Data;
                }
                else
                {
                    ThrowException(BaseUrl, request, response);
                    return default(T);
                }
            }
            return item;
        }

        public async Task<T> MakeRequestFromCacheAsync<T>(IRestRequest request, string cacheKey, int cacheMinutes = 30) where T : class, new()
        {
            var item = _cache.Get<T>(cacheKey);
            if (item == null) //If the cache doesn't have the item
            {
                var response = await ExecuteTaskAsync<T>(request); //Get the item from the API call
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _cache.Set(cacheKey, response.Data, cacheMinutes); //Set that item into the cache so we can get it next time
                    item = response.Data;
                }
                else
                {
                    ThrowException(BaseUrl, request, response);
                    return default(T);
                }
            }
            return item;
        }
    }
}

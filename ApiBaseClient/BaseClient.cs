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
    // Based on ultimate RestSharp client
    // https://exceptionnotfound.net/building-the-ultimate-restsharp-client-in-asp-net-and-csharp/
    public class BaseClient : IBaseClient
    {
        protected ICacheService _cache;
        private readonly ILogger _logger;
        private readonly IRestClient _restClient;

        public BaseClient(string baseUrl, ICacheService cache, IEnumerable<string> contentTypes, IDeserializer deserializer, IAuthenticator authenticator, ILoggerFactory loggerFactory)
        {
            _cache = cache;
            _logger = loggerFactory.CreateLogger<BaseClient>();

            _restClient = new RestClient()
            {
                BaseUrl = new Uri(baseUrl),
                Authenticator = authenticator
            };

            foreach (string contentType in contentTypes)
            {
                _restClient.AddHandler(contentType, () => deserializer);
            }
        }

        public BaseClient(IRestClient restClient, ICacheService cache, ILoggerFactory loggerFactory)
        {
            _cache = cache;
            _logger = loggerFactory.CreateLogger<BaseClient>();
            _restClient = restClient;
        }

        private void ThrowException(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, the status code, and the parameters.
            string info = "Request to " + BaseUrl.AbsoluteUri + request.Resource + " failed with status code " + response.StatusCode + ", parameters: "
                + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            ApiException apiException;
            if (response != null && response.ErrorException != null)
            {
                apiException = new ApiException(
                                (int)response.StatusCode,
                                BaseUrl.AbsoluteUri + request.Resource,
                                request.Method.ToString(),
                                string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray()),
                                response.Content,
                                info,
                                response.ErrorException
                                );
            }
            else
            {
                apiException = new ApiException(
                                (int)response.StatusCode,
                                BaseUrl.AbsoluteUri + request.Resource,
                                request.Method.ToString(),
                                string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray()),
                                response.Content,
                                info
                                );
            }

            // Could log here rather than throwing exception as in original example but probably best to fail fast.
            //_logger.LogError(apiException, info);
            throw apiException;
        }

        private bool TimeoutCheck(IRestRequest request, IRestResponse response)
        {
            if (response.StatusCode == 0)
            {
                ThrowException(_restClient.BaseUrl, request, response);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IRestResponse Execute(IRestRequest request)
        {
            return ExecuteTaskAsync(request).Result;
        }

        public IRestResponse<T> Execute<T>(IRestRequest request)
        {
            return ExecuteTaskAsync<T>(request).Result;
        }

        public async Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            var response = await _restClient.ExecuteTaskAsync(request);
            TimeoutCheck(request, response);
            return response;
        }

        public async Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            var response = await _restClient.ExecuteTaskAsync<T>(request);
            TimeoutCheck(request, response);
            return response;
        }

        public T MakeRequest<T>(IRestRequest request) where T : new()
        {
            return MakeRequestAsync<T>(request).Result;
        }

        public void MakeRequest(IRestRequest request)
        {
            MakeRequestAsync(request).Wait();
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
                ThrowException(_restClient.BaseUrl, request, response);
                return default(T);
            }
        }

        public async Task MakeRequestAsync(IRestRequest request)
        {
            var response = await ExecuteTaskAsync(request);
            if (!response.IsSuccessful)
            {
                ThrowException(_restClient.BaseUrl, request, response);
            }
        }

        public T MakeRequestFromCache<T>(IRestRequest request, string cacheKey, int cacheMinutes = 30) where T : class, new()
        {
            return MakeRequestFromCacheAsync<T>(request, cacheKey, cacheMinutes).Result;
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
                    ThrowException(_restClient.BaseUrl, request, response);
                }
            }
            return item;
        }
    }
}

using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotMailerCore
{
    /// <summary>
    /// A HTTP client wrapper for interacting with an API
    /// </summary>
    public interface IBaseClient
    {
        /// <summary>
        /// Make the call to the API server.
        /// </summary>
        /// <param name="request">The parameters for the API call</param>
        /// <returns>Response object</returns>
        T MakeRequest<T>(IRestRequest request) where T : new();

        /// <summary>
        /// Make the call to the API server.
        /// </summary>
        /// <param name="request">The parameters for the API call</param>
        void MakeRequest(IRestRequest request);

        /// <summary>
        /// Make the async call to the API server.
        /// </summary>
        /// <param name="request">The parameters for the API call</param>
        /// <returns>Response object</returns>
        Task<T> MakeRequestAsync<T>(IRestRequest request) where T : new();

        /// <summary>
        /// Make the async call to the API server.
        /// </summary>
        /// <param name="request">The parameters for the API call</param>
        Task MakeRequestAsync(IRestRequest request);

        /// <summary>
        /// Make the async call to the API server storing/retrieving from the cache.
        /// </summary>
        /// <param name="request">The parameters for the API call</param>
        /// <param name="cacheKey">Unique key for cache storage/retrival</param>
        /// <param name="cacheMinutes">Length of time response is cached for</param>
        T MakeRequestFromCache<T>(IRestRequest request, string cacheKey, int cacheMinutes = 30) where T : class, new();

        /// <summary>
        /// Make the async call to the API server storing/retrieving from the cache.
        /// </summary>
        /// <param name="request">The parameters for the API call</param>
        /// <param name="cacheKey">Unique key for cache storage/retrival</param>
        /// <param name="cacheMinutes">Length of time response is cached for</param>
        Task<T> MakeRequestFromCacheAsync<T>(IRestRequest request, string cacheKey, int cacheMinutes = 30) where T : class, new();
    }
}

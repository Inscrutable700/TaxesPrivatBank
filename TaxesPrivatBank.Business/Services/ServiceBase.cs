using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace TaxesPrivatBank.Business.Services
{
    /// <summary>
    /// The service base.
    /// </summary>
    public class ServiceBase
    {
        /// <summary>
        /// The service URL.
        /// </summary>
        private string serviceUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="serviceUrl">The service URL.</param>
        public ServiceBase(string serviceUrl)
        {
            this.serviceUrl = serviceUrl;
        }
        
        /// <summary>
        /// Gets the post response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="apiEndpoint">The API endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected T GetPOSTResponse<T>(string apiEndpoint, Dictionary<string, string> parameters)
            where T : new()
        {
            RestClient client = new RestClient(new Uri(this.serviceUrl));
            RestRequest request = new RestRequest(apiEndpoint, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            request.AddBody(parameters);

            var response = client.Execute<T>(request);
            T responseData = response.Data;
            return responseData;
        }

        /// <summary>
        /// Gets the get response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndpoint">The API endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="authorizationHeader">The authorization header.</param>
        /// <returns></returns>
        protected T GetGETResponse<T>(string apiEndpoint, Dictionary<string, string> parameters, string authorizationHeader = null)
            where T : new()
        {
            RestClient client = new RestClient(new Uri(this.serviceUrl));
            RestRequest request = new RestRequest(apiEndpoint, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            // Add authorization header if it needed
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                request.AddHeader("Authorization", authorizationHeader);
            }

            // Add query string parameters
            foreach(KeyValuePair<string, string> parameter in parameters)
            {
                request.AddQueryParameter(parameter.Key, parameter.Value);
            }
            
            var response = client.Execute<T>(request);
            T responseData = response.Data;
            return responseData;
        }
    }
}

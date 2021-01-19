using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using NUnitTestBandsApi.Resources;

namespace NUnitTestBandsApi.Requests
{
    class RequestHelper
    {
        public static IRestClient restClient;
        public static IRestRequest restRequest;
        public static string baseUri;

        public static string SetBaseUrl(string resource)
        {
            return baseUri + resource;
        }

        public static string SetUrl(string resource, string endpoint)
        {
            StringBuilder stringBuilder = new StringBuilder(Config.baseUri);
            stringBuilder.Append(resource);
            stringBuilder.Append("/");
            stringBuilder.Append(endpoint);

            return stringBuilder.ToString();
        }

        public static IRestResponse PostRequest(string url, string jsonBody)
        {
            restClient = new RestClient();
            restRequest = new RestRequest();
            restRequest.Resource = url;
            SetHeaders();
            restRequest.AddJsonBody(jsonBody);
            return restClient.Post(restRequest);
        }

        public static IRestResponse GetRequest(string url)
        {
            restClient = new RestClient();
            restRequest = new RestRequest();
            restRequest.Resource = url;
            SetHeaders();
            return restClient.Get(restRequest);
        }

        public static IRestResponse DeleteRequest(string url)
        {
            restClient = new RestClient();
            restRequest = new RestRequest();
            restRequest.Resource = url;
            SetHeaders();
            return restClient.Delete(restRequest);
        }

        public static IRestResponse PutRequest(string url, string jsonBody)
        {
            restClient = new RestClient();
            restRequest = new RestRequest();
            restRequest.Resource = url;
            SetHeaders();
            restRequest.AddJsonBody(jsonBody);
            return restClient.Put(restRequest);
        }

        public static void SetHeaders()
        {
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
        }
    }
}

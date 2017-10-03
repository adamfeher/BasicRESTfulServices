using System.Net.Http;
using System.Collections.Generic;

namespace BasicRESTfulServices
{
    public static class HTTP
    {
        // One client across all requests, created on first use.
        private static HttpClient _HttpClient;
        public static HttpClient HttpClient
        {
            get
            {
                return (_HttpClient == null) ? _HttpClient = new HttpClient() : _HttpClient;
            }
        }
        
        public static string SendRequest(HttpMethod method, string uri, Dictionary<string,string> headers = null, string content = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, uri);

            // Copy header items into request if present.

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            // Could replace .Result with ContinueWith if async requests were desired.
            // Sending of the request and reading of the response could be separated for easier use at the test case layer.
            HttpResponseMessage response = HttpClient.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}

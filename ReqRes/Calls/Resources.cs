using BasicRESTfulServices.ReqRes.JsonObjects;
using System.Collections.Generic;
using System.Net.Http;

namespace BasicRESTfulServices.ReqRes.Calls
{
    public static class Resources
    {
        public static List<Resource> ListMultiple(int pageNum, int pageSize)
        {
            string response = HTTP.SendRequest(HttpMethod.Get, $"{URIs.Resources}?page={pageNum}&per_page={pageSize}");
            return JSON.DeserializeAnon<List<Resource>>(response);
        }

        public static Resource ListSingle(int id)
        {
            string response = HTTP.SendRequest(HttpMethod.Get, $"{URIs.Resources}/{id}");
            return JSON.DeserializeAnon<Resource>(response);
        }
    }
}

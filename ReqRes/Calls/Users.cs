using BasicRESTfulServices.ReqRes.JsonObjects;
using System.Collections.Generic;
using System.Net.Http;

namespace BasicRESTfulServices.ReqRes.Calls
{
    public static class Users
    {
        public static List<User> ListMultiple(int pageNum, int pageSize)
        {
            string response = HTTP.SendRequest(HttpMethod.Get, $"{URIs.Users}?page={pageNum}&per_page={pageSize}");
            return JSON.DeserializeAnon<List<User>>(response);
        }

        public static User ListSingle(int id)
        {
            string response = HTTP.SendRequest(HttpMethod.Get, $"{URIs.Users}/{id}");
            return JSON.DeserializeAnon<User>(response);
        }
    }
}

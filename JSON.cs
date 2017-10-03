using Newtonsoft.Json;

namespace BasicRESTfulServices
{
    public class JSON
    {
        // Some responses contain paging details which is purposefully not used in this sample.
        // The method below is an example of a generic (and easy) way to strip unnecessary wrapped data.

        public static T DeserializeAnon<T>(string toDeserialize)
        {
            var anonObject = new { page = "", per_page = "", total = "", total_pages = "", data = default(T) };
            var deserialized = JsonConvert.DeserializeAnonymousType(toDeserialize, anonObject);
            return deserialized.data;
        }
    }
}

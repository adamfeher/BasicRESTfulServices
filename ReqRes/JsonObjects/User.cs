using Newtonsoft.Json;

namespace BasicRESTfulServices.ReqRes.JsonObjects
{ 
    // Modelled after the type returned under 'data' for List Users and Single User calls
    // freely available for testing use at https://reqres.in/

    // This example shows how the JsonProperty attribute can be used to rename certain properties
    // to align with particular coding styles.
    public class User
    {
        public int id { get; set; }
        [JsonProperty("first_name")]
        public string firstName { get; set; }
        [JsonProperty("last_name")]
        public string lastName { get; set; }
        public string avatar { get; set; }
    }
}

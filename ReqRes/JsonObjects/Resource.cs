using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BasicRESTfulServices.ReqRes.JsonObjects
{
    // Modelled after the type returned for List <RESOURCE> and Single <RESOURCE> calls
    // freely available for testing use at https://reqres.in/

    // This example shows how the JsonExtensionData attribute can be used to remove unwanted clutter by
    // condensing some of the properties, which may not yet be used, into a single dictionary.
    public class Resource
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }

        // Based on the respone, this would hide the "year" and "pantone_value" properties.
        [JsonExtensionData]
        public IDictionary<string, JToken> extras { get; set; } 
    }
}

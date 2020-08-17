using Newtonsoft.Json;
using System;

namespace Roket.NET
{
    public class ResultResponse<T>
    {
        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "requestAt")]
        public DateTime RequestAt { get; set; }

        [JsonProperty(PropertyName = "responseAt")]
        public DateTime ResponseAt { get; set; }

        [JsonProperty(PropertyName = "requestToken")]
        public string RequestToken { get; set; }

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }
    }
}

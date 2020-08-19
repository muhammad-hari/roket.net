using Newtonsoft.Json;
using System;

namespace Roket.NET.Models.API
{
    public class ApiConfig
    {
        [JsonProperty(PropertyName = "Api")]
        public string Api { get; set; }

        public string Client { get; set; }

    }
}

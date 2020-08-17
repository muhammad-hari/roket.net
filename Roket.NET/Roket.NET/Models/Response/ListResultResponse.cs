using Newtonsoft.Json;

namespace Roket.NET
{
    public class ListResultResponse<T> : ResultResponse<T>
    {
        [JsonProperty(PropertyName = "info")]
        public PageInfo Info { get; set; }
    }
}

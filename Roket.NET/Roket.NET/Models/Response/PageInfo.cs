using Newtonsoft.Json;

namespace Roket.NET
{
    public class PageInfo
    {
        [JsonProperty(PropertyName = "totalPage")]
        public int TotalPage { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonProperty(PropertyName = "totalItem")]
        public int TotalItem { get; set; }
    }
}

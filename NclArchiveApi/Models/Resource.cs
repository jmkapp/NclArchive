using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Resource
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
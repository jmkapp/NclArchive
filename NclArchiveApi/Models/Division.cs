using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Division
    {
        [JsonProperty(PropertyName = "divisionId")]
        public string DivisionId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
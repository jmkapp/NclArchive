using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Club
    {
        [JsonProperty(PropertyName = "clubId")]
        public string ClubId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
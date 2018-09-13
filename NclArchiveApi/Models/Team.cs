using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Team
    {
        [JsonProperty(PropertyName = "teamId")]
        public string TeamId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }
        [JsonProperty(PropertyName = "nclTeam")]
        public string NclTeam { get; set; }
        [JsonProperty(PropertyName = "teamRef")]
        public string TeamRef { get; set; }
        [JsonProperty(PropertyName = "isDirty")]
        public string IsDirty { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "sponsorName")]
        public string SponsorName { get; set; }
        [JsonProperty(PropertyName = "sponsorUrl")]
        public string SponsorUrl { get; set; }
        [JsonProperty(PropertyName = "miniName")]
        public string MiniName { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
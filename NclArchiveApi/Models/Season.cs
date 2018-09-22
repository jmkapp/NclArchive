using System;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Season
    {
        [JsonProperty(PropertyName = "seasonId")]
        public string SeasonId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime? StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public DateTime? EndDate { get; set; }
        [JsonProperty(PropertyName = "winterSeason")]
        public bool WinterSeason { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
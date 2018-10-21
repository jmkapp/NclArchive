using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Venue
    {
        [JsonProperty(PropertyName = "venueId")]
        public int VenueId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
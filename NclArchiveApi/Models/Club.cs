using System.Collections.Generic;
using DatabaseAccess.ExternalModel;
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
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "venueId")]
        public string VenueId { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "imageFile")]
        public string ImageFile { get; set; }
        [JsonProperty(PropertyName = "contactName")]
        public string ContactName { get; set; }
        [JsonProperty(PropertyName = "addressLine1")]
        public string AddressLine1 { get; set; }
        [JsonProperty(PropertyName = "addressLine2")]
        public string AddressLine2 { get; set; }
        [JsonProperty(PropertyName = "addressLine3")]
        public string AddressLine3 { get; set; }
        [JsonProperty(PropertyName = "postcode")]
        public string Postcode { get; set; }
        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get; set; }
        [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }
        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }
        [JsonProperty(PropertyName = "associationId")]
        public string AssociationId { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "teamsLink")]
        public string TeamsLink { get; set; }
        [JsonProperty(PropertyName = "teams")]
        public IEnumerable<Team> Teams { get; set; }
    }
}
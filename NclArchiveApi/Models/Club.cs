using System.Collections.Generic;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Club
    {
        [JsonProperty(PropertyName = "clubId")]
        public int ClubId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "venueId")]
        public int? VenueId { get; set; }
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
        public int? CustomerId { get; set; }
        [JsonProperty(PropertyName = "associationId")]
        public int? AssociationId { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "teamsLink")]
        public string TeamsLink { get; set; }
        [JsonProperty(PropertyName = "teams")]
        public IEnumerable<Team> Teams { get; set; }

        internal static Club Convert(DatabaseAccess.ExternalModel.Club club)
        {
            Club newClub = new Club();
            newClub.ClubId = club.ClubId;
            newClub.ShortName = club.ShortName;
            newClub.LongName = club.LongName;
            newClub.Description = club.Description;
            newClub.VenueId = club.VenueId;
            newClub.Url = club.Url;
            newClub.ImageFile = club.ImageFile;
            newClub.ContactName = club.ContactName;
            newClub.AddressLine1 = club.AddressLine1;
            newClub.AddressLine2 = club.AddressLine2;
            newClub.AddressLine3 = club.AddressLine3;
            newClub.Postcode = club.Postcode;
            newClub.Telephone = club.Telephone;
            newClub.Fax = club.Fax;
            newClub.CustomerId = club.CustomerId;
            newClub.AssociationId = club.AssociationId;

            return newClub;
        }
    }
}
using System.Security.Policy;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Venue
    {
        [JsonProperty(PropertyName = "venueId")]
        public int VenueId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }
        [JsonProperty(PropertyName = "capacity")]
        public int? Capacity { get; set; }
        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }
        [JsonProperty(PropertyName = "address2")]
        public string Address2 { get; set; }
        [JsonProperty(PropertyName = "address3")]
        public string Address3 { get; set; }
        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get; set; }
        [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }
        [JsonProperty(PropertyName = "directions")]
        public string Directions { get; set; }
        [JsonProperty(PropertyName = "streetMapUri")]
        public string StreetMapUri { get; set; }
        [JsonProperty(PropertyName = "customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty(PropertyName = "associationId")]
        public int? AssociationId { get; set; }
        [JsonProperty(PropertyName = "postcode")]
        public string Postcode { get; set; }
        [JsonProperty(PropertyName = "hideItem")]
        public bool HideItem { get; set; }
        [JsonProperty(PropertyName = "imageFile")]
        public string ImageFile { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        internal static Venue Convert(DatabaseAccess.ExternalModel.Venue venue)
        {
            Venue newVenue = new Venue();
            newVenue.VenueId = venue.VenueId;
            newVenue.ShortName = venue.ShortName;
            newVenue.LongName = venue.LongName;
            newVenue.Capacity = venue.Capacity;
            newVenue.Address1 = venue.Address1;
            newVenue.Address2 = venue.Address2;
            newVenue.Address3 = venue.Address3;
            newVenue.Telephone = venue.Telephone;
            newVenue.Fax = venue.Fax;
            newVenue.Directions = venue.Directions;
            newVenue.StreetMapUri = venue.StreetMapUri;
            newVenue.CustomerId = venue.CustomerId;
            newVenue.AssociationId = venue.AssociationId;
            newVenue.Postcode = venue.Postcode;
            newVenue.HideItem = venue.HideItem;
            newVenue.ImageFile = venue.ImageFile;

            return newVenue;
        }
    }
}
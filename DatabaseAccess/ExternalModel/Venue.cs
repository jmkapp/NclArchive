namespace DatabaseAccess.ExternalModel
{
    public class Venue
    {
        private readonly int _venueId;
        private readonly string _shortName;
        private readonly string _longName;
        private readonly int? _capacity;
        private readonly string _address1;
        private readonly string _address2;
        private readonly string _address3;
        private readonly string _telephone;
        private readonly string _fax;
        private readonly string _directions;
        private readonly string _streetMapUri;
        private readonly int? _customerId;
        private readonly int? _associationId;
        private readonly string _postcode;
        private readonly bool _hideItem;
        private readonly string _imageFile;

        public Venue(
            int venueId,
            string shortName,
            string longName,
            int? capacity,
            string address1,
            string address2,
            string address3,
            string telephone,
            string fax,
            string directions,
            string streetMapUri,
            int? customerId,
            int? associationId,
            string postcode,
            bool hideItem,
            string imageFile)
        {
            _venueId = venueId;
            _shortName = shortName;
            _longName = longName;
            _capacity = capacity;
            _address1 = address1;
            _address2 = address2;
            _address3 = address3;
            _telephone = telephone;
            _fax = fax;
            _directions = directions;
            _streetMapUri = streetMapUri;
            _customerId = customerId;
            _associationId = associationId;
            _postcode = postcode;
            _hideItem = hideItem;
            _imageFile = imageFile;
        }

        public int VenueId => _venueId;

        public string ShortName => _shortName;

        public string LongName => _longName;

        public int? Capacity => _capacity;

        public string Address1 => _address1;

        public string Address2 => _address2;

        public string Address3 => _address3;

        public string Telephone => _telephone;

        public string Fax => _fax;

        public string Directions => _directions;

        public string StreetMapUri => _streetMapUri;

        public int? CustomerId => _customerId;

        public int? AssociationId => _associationId;

        public string Postcode => _postcode;

        public bool HideItem => _hideItem;

        public string ImageFile => _imageFile;

        internal static Venue Convert(InternalModel.Venue venue)
        {
            return new Venue(
                venue.VenueId,
                venue.ShortName,
                venue.LongName,
                venue.Capacity,
                venue.Address1,
                venue.Address2,
                venue.Address3,
                venue.Telephone,
                venue.Fax,
                venue.Directions,
                venue.StreetmapUri,
                venue.CustomerId,
                venue.AssociationId,
                venue.Postcode,
                venue.HideItem,
                venue.ImageFile);
        }
    }
}

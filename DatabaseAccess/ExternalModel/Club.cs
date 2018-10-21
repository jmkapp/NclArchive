namespace DatabaseAccess.ExternalModel
{
    public class Club
    {
        private readonly int _clubId;
        private readonly string _shortName;
        private readonly string _longName;
        private readonly string _description;
        private readonly int? _venueId;
        private readonly string _url;
        private readonly string _imageFile;
        private readonly string _contactName;
        private readonly string _addressLine1;
        private readonly string _addressLine2;
        private readonly string _addressLine3;
        private readonly string _postcode;
        private readonly string _telephone;
        private readonly string _fax;
        private readonly int? _customerId;
        private readonly int? _associationId;

        public Club(
            int clubId,
            string shortName,
            string longName,
            string description,
            int? venueId,
            string url,
            string imageFile,
            string contactName,
            string addressLine1,
            string addressLine2,
            string addressLine3,
            string postcode,
            string telephone,
            string fax,
            int? customerId,
            int? associationId)
        {
            _clubId = clubId;
            _shortName = shortName;
            _longName = longName;
            _description = description;
            _venueId = venueId;
            _url = url;
            _imageFile = imageFile;
            _contactName = contactName;
            _addressLine1 = addressLine1;
            _addressLine2 = addressLine2;
            _addressLine3 = addressLine3;
            _postcode = postcode;
            _telephone = telephone;
            _fax = fax;
            _customerId = customerId;
            _associationId = associationId;
        }

        public int ClubId
        {
            get { return _clubId; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public string LongName
        {
            
            get { return _longName; }
        }

        public string Description
        {
            get { return _description; }
        }

        public int? VenueId
        {
            get { return _venueId; }
        }

        public string Url
        {
            get { return _url; }
        }

        public string ImageFile
        {
            get { return _imageFile; }
        }

        public string ContactName
        {
            get { return _contactName; }
        }

        public string AddressLine1
        {
            get { return _addressLine1; }
        }

        public string AddressLine2
        {
            get { return _addressLine2; }
        }

        public string AddressLine3
        {
            get { return _addressLine3; }
        }

        public string Postcode
        {
            get { return _postcode; }
        }

        public string Telephone
        {
            get { return _telephone; }
        }

        public string Fax
        {
            get { return _fax; }
        }

        public int? CustomerId
        {
            get { return _customerId; }
        }

        public int? AssociationId
        {
            get { return _associationId; }
        }

        internal static Club Convert(InternalModel.Club club)
        {
            return new Club(
                club.ClubId,
                club.ShortName,
                club.LongName,
                club.Description,
                club.VenueId,
                club.Url,
                club.ImageFile,
                club.ContactName,
                club.AddressLine1,
                club.AddressLine2,
                club.AddressLine3,
                club.Postcode,
                club.Telephone,
                club.Fax,
                club.CustomerId,
                club.AssociationId
            );
        }
    }
}


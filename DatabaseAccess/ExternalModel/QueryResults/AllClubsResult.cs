namespace DatabaseAccess.ExternalModel.QueryResults
{
    public class AllClubsResult
    {
        private readonly int _clubId;
        private readonly string _shortName;
        private readonly string _longName;
        public AllClubsResult(int clubId, string shortName, string longName)
        {
            _clubId = clubId;
            _shortName = shortName;
            _longName = longName;
        }
        public int ClubId
        {
            get { return _clubId; }
        }
        public string LongName
        {
            get
            {
                return _longName;
            }
        }
        public string ShortName
        {
            get
            {
                return _shortName;
            }
        }
    }
}
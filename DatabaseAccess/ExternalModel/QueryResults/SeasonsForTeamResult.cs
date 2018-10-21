namespace DatabaseAccess.ExternalModel.QueryResults
{
    public class SeasonsForTeamResult
    {
        private readonly int _seasonId;
        private readonly string _shortName;

        public SeasonsForTeamResult(int seasonId, string shortName)
        {
            _seasonId = seasonId;
            _shortName = shortName;
        }

        public int SeasonId
        {
            get { return _seasonId; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }
    }
}

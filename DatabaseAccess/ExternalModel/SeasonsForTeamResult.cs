namespace DatabaseAccess.ExternalModel
{
    public class SeasonsForTeamResult
    {
        private readonly string _seasonId;
        private readonly string _shortName;

        public SeasonsForTeamResult(string seasonId, string shortName)
        {
            _seasonId = seasonId;
            _shortName = shortName;
        }

        public string SeasonId
        {
            get { return _seasonId; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }
    }
}

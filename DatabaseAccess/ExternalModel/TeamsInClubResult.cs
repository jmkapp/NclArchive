namespace DatabaseAccess.ExternalModel
{
    public class TeamsInClubResult
    {
        private readonly string _teamId;
        private readonly string _teamName;
        private readonly bool _nclTeam;
        private readonly string _longName;

        public TeamsInClubResult(string teamId, string teamName, bool nclTeam, string longName)
        {
            _teamId = teamId;
            _teamName = teamName;
            _nclTeam = nclTeam;
            _longName = longName;
        }

        public string TeamId
        {
            get { return _teamId; }
        }

        public string TeamName
        {
            get { return _teamName; }
        }

        public bool NclTeam
        {
            get { return _nclTeam; }
        }

        public string LongName
        {
            get { return _longName; }
        }
    }
}
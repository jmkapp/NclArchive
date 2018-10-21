namespace DatabaseAccess.ExternalModel
{
    public class Team
    {
        private readonly int _teamId;
        private readonly Club _club;
        private readonly string _shortName;
        private readonly string _longName;
        private readonly string _teamRef;
        private readonly string _isDirty;
        private readonly string _url;
        private readonly string _sponsorsName;
        private readonly string _sponsorsUrl;
        private readonly string _miniName;

        public Team(
            int teamId,
            Club club,
            string shortName,
            string longName,
            string teamRef,
            string isDirty,
            string url,
            string sponsorsName,
            string sponsorsUrl,
            string miniName)
        {
            _teamId = teamId;
            _club = club;
            _shortName = shortName;
            _longName = longName;
            _teamRef = teamRef;
            _isDirty = isDirty;
            _url = url;
            _sponsorsName = sponsorsName;
            _sponsorsUrl = sponsorsUrl;
            _miniName = miniName;
        }

        public int TeamId
        {
            get { return _teamId; }
        }

        public Club Club
        {
            get { return _club; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public string LongName
        {
            get { return _longName; }
        }

        public string TeamRef
        {
            get { return _teamRef; }
        }

        public string IsDirty
        {
            get { return _isDirty; }
        }

        public string Url
        {
            get { return _url; }
        }

        public string SponsorsName
        {
            get { return _sponsorsName; }
        }

        public string SponsorsUrl
        {
            get { return _sponsorsUrl; }
        }

        public string MiniName
        {
            get { return _miniName; }
        }

        internal static Team Convert(InternalModel.Team team)
        {
            return new Team(
                team.TeamId,
                team.Club == null ? null : Club.Convert(team.Club),
                team.ShortName,
                team.LongName,
                team.TeamRef,
                team.IsDirty.ToString(),
                team.Url,
                team.SponsorsName,
                team.SponsorsUrl,
                team.MiniName
                );
        }
    }
}
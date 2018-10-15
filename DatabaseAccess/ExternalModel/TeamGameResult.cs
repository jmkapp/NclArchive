using System;

namespace DatabaseAccess.ExternalModel
{
    public class TeamGameResult
    {
        private readonly string _gameId;
        private readonly string _shortName;
        private readonly string _homeTeamId;
        private readonly Team _homeTeam;
        private readonly string _awayTeamId;
        private readonly Team _awayTeam;
        private readonly string _homeTeamHtScore;
        private readonly string _awayTeamHtScore;
        private readonly string _homeTeamScore;
        private readonly string _awayTeamScore;
        private readonly string _gameDate;
        private readonly string _venueId;
        private readonly string _divisionId;
        private readonly string _divisionName;
        private readonly string _dDate;
        private readonly string _tTime;
        private readonly string _gameStatus;
        private readonly string _comp;
        private readonly string _compCupPoId;
        private readonly string _gameTypeId;
        private readonly int _seasonId;
        private readonly string _seasonName;
        private readonly Season _season;
        private readonly string _homeTeamName;
        private readonly string _awayTeamName;

        public TeamGameResult(
            string shortName,
            string gameId,
            string homeTeamId,
            Team homeTeam,
            string awayTeamId,
            Team awayTeam,
            string homeTeamHtScore,
            string awayTeamHtScore,
            string homeTeamScore,
            string awayTeamScore,
            string gameDate,
            string venueId,
            string divisionId,
            string divisionName,
            string dDate,
            string tTime,
            string gameStatus,
            string comp,
            string compCupPoId,
            string gameTypeId,
            int seasonId,
            string seasonName,
            Season season,
            string homeTeamName,
            string awayTeamName
        )
        {
            _shortName = shortName;
            _gameId = gameId;
            _homeTeamId = homeTeamId;
            _homeTeam = homeTeam;
            _awayTeamId = awayTeamId;
            _awayTeam = awayTeam;
            _homeTeamHtScore = homeTeamHtScore;
            _awayTeamHtScore = awayTeamHtScore;
            _homeTeamScore = homeTeamScore;
            _awayTeamScore = awayTeamScore;
            _gameDate = gameDate;
            _venueId = venueId;
            _divisionId = divisionId;
            _divisionName = divisionName;
            _dDate = dDate;
            _tTime = tTime;
            _gameStatus = gameStatus;
            _comp = comp;
            _compCupPoId = compCupPoId;
            _gameTypeId = gameTypeId;
            _seasonId = seasonId;
            _seasonName = seasonName;
            _season = season;
            _homeTeamName = homeTeamName;
            _awayTeamName = awayTeamName;
        }

        public string GameId
        {
            get { return _gameId; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public string HomeTeamId
        {
            get { return _homeTeamId; }
        }

        public Team HomeTeam
        {
            get { return _homeTeam; }
        }

        public string AwayTeamId
        {
            get { return _awayTeamId; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
        }

        public string HomeTeamHtScore
        {
            get { return _homeTeamHtScore; }
        }

        public string AwayTeamHtScore
        {
            get { return _awayTeamHtScore; }
        }

        public string HomeTeamScore
        {
            get { return _homeTeamScore; }
        }

        public string AwayTeamScore
        {
            get { return _awayTeamScore; }
        }

        public string GameDate
        {
            get { return _gameDate; }
        }

        public string VenueId
        {
            get { return _venueId; }
        }

        public string DivisionId
        {
            get { return _divisionId; }
        }

        public string CompCupPoId
        {
            get { return _compCupPoId; }
        }

        public string GameTypeId
        {
            get { return _gameTypeId; }
        }

        public string DDate
        {
            get { return _dDate; }
        }

        public string TTime
        {
            get { return _tTime; }
        }

        public string GameStatus
        {
            get { return _gameStatus; }
        }

        public string Comp
        {
            get { return _comp; }
        }

        public int SeasonId
        {
            get { return _seasonId; }
        }

        public Season Season
        {
            get { return _season; }
        }

        public string DivisionName
        {
            get { return _divisionName; }
        }

        public string SeasonName
        {
            get { return _seasonName; }
        }

        public string HomeTeamName
        {
            get { return _homeTeamName; }
        }

        public string AwayTeamName
        {
            get { return _awayTeamName; }
        }
    }
}

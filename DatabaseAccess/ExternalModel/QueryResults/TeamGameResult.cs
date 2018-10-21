using System;

namespace DatabaseAccess.ExternalModel.QueryResults
{
    public class TeamGameResult
    {
        private readonly int _gameId;
        private readonly string _shortName;
        private readonly int? _homeTeamId;
        private readonly Team _homeTeam;
        private readonly int? _awayTeamId;
        private readonly Team _awayTeam;
        private readonly int? _homeTeamHtScore;
        private readonly int? _awayTeamHtScore;
        private readonly int _homeTeamScore;
        private readonly int _awayTeamScore;
        private readonly DateTime? _gameDate;
        private readonly Venue _venue;
        private readonly Division _division;
        private readonly string _dDate;
        private readonly int _tTime;
        private readonly string _gameStatus;
        private readonly string _comp;
        private readonly int _compCupPoId;
        private readonly int? _gameTypeId;
        private readonly int _seasonId;
        private readonly string _seasonName;
        private readonly Season _season;
        private readonly string _homeTeamName;
        private readonly string _awayTeamName;

        public TeamGameResult(
            string shortName,
            int gameId,
            int? homeTeamId,
            Team homeTeam,
            int? awayTeamId,
            Team awayTeam,
            int? homeTeamHtScore,
            int? awayTeamHtScore,
            int homeTeamScore,
            int awayTeamScore,
            DateTime? gameDate,
            Venue venue,
            Division division,
            string dDate,
            int tTime,
            string gameStatus,
            string comp,
            int compCupPoId,
            int? gameTypeId,
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
            _venue = venue;
            _division = division;
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

        public int GameId
        {
            get { return _gameId; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public int? HomeTeamId
        {
            get { return _homeTeamId; }
        }

        public Team HomeTeam
        {
            get { return _homeTeam; }
        }

        public int? AwayTeamId
        {
            get { return _awayTeamId; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
        }

        public int? HomeTeamHtScore
        {
            get { return _homeTeamHtScore; }
        }

        public int? AwayTeamHtScore
        {
            get { return _awayTeamHtScore; }
        }

        public int HomeTeamScore
        {
            get { return _homeTeamScore; }
        }

        public int AwayTeamScore
        {
            get { return _awayTeamScore; }
        }

        public DateTime? GameDate
        {
            get { return _gameDate; }
        }

        public Venue Venue
        {
            get { return _venue; }
        }

        public Division Division
        {
            get { return _division; }
        }

        public int CompCupPoId
        {
            get { return _compCupPoId; }
        }

        public int? GameTypeId
        {
            get { return _gameTypeId; }
        }

        public string DDate
        {
            get { return _dDate; }
        }

        public int TTime
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

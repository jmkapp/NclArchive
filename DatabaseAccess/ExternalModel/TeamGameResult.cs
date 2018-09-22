using System;

namespace DatabaseAccess.ExternalModel
{
    public class TeamGameResult
    {
        private readonly int _gameId;
        private readonly int _gameType;
        private readonly string _shortName;
        private readonly int? _homeTeamId;
        private readonly int? _awayTeamId;
        private readonly int? _homeTeamHtScore;
        private readonly int? _awayTeamHtScore;
        private readonly int _homeTeamScore;
        private readonly int _awayTeamScore;
        private readonly DateTime _gameDate;
        private readonly int _venueId;
        private readonly int? _refereeId;
        private readonly int? _line1Id;
        private readonly int? _line2Id;
        private readonly int _divisionId;
        private readonly int _compCupPoId;
        private readonly int? _gameTypeId;
        private readonly int _status;
        private readonly string _dDate;
        private readonly int _tTime;
        private readonly string _gameStatus;
        private readonly string _comp;
        private readonly string _compUrl;
        private readonly int _seasonId;
        private readonly string _divisionName;
        private readonly string _seasonName;
        private readonly string _homeNclTeam;
        private readonly string _awayNclTeam;
        private readonly string _homeTeam;
        private readonly string _awayTeam;
        private readonly string _longHomeTeam;
        private readonly string _longAwayTeam;

        public TeamGameResult(
            int gameType,
            string shortName,
            int gameId,
            int? homeTeamId,
            int? awayTeamId,
            int? homeTeamHtScore,
            int? awayTeamHtScore,
            int homeTeamScore,
            int awayTeamScore,
            DateTime gameDate,
            int venueId,
            int? refereeId,
            int? line1Id,
            int? line2Id,
            int divisionId,
            int compCupPoId,
            int? gameTypeId,
            int status,
            string dDate,
            int tTime,
            string gameStatus,
            string comp,
            string compUrl,
            int seasonId,
            string divisionName,
            string seasonName,
            string homeNclTeam,
            string awayNclTeam,
            string homeTeam,
            string awayTeam,
            string longHomeTeam,
            string longAwayTeam
        )
        {
            _gameType = gameType;
            _shortName = shortName;
            _gameId = gameId;
            _homeTeamId = homeTeamId;
            _awayTeamId = awayTeamId;
            _homeTeamHtScore = homeTeamHtScore;
            _awayTeamHtScore = awayTeamHtScore;
            _homeTeamScore = homeTeamScore;
            _awayTeamScore = awayTeamScore;
            _gameDate = gameDate;
            _venueId = venueId;
            _refereeId = refereeId;
            _line1Id = line1Id;
            _line2Id = line2Id;
            _divisionId = divisionId;
            _compCupPoId = compCupPoId;
            _gameTypeId = gameTypeId;
            _status = status;
            _dDate = dDate;
            _tTime = tTime;
            _gameStatus = gameStatus;
            _comp = comp;
            _compUrl = compUrl;
            _seasonId = seasonId;
            _divisionName = divisionName;
            _seasonName = seasonName;
            _homeNclTeam = homeNclTeam;
            _awayNclTeam = awayNclTeam;
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _longHomeTeam = longHomeTeam;
            _longAwayTeam = longAwayTeam;
        }

        public int GameId
        {
            get { return _gameId; }
        }

        public int GameType
        {
            get { return _gameType; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public int? HomeTeamId
        {
            get { return _homeTeamId; }
        }

        public int? AwayTeamId
        {
            get { return _awayTeamId; }
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

        public DateTime GameDate
        {
            get { return _gameDate; }
        }

        public int VenueId
        {
            get { return _venueId; }
        }

        public int? RefereeId
        {
            get { return _refereeId; }
        }

        public int? Line1Id
        {
            get { return _line1Id; }
        }

        public int? Line2Id
        {
            get { return _line2Id; }
        }

        public int DivisionId
        {
            get { return _divisionId; }
        }

        public int CompCupPoId
        {
            get { return _compCupPoId; }
        }

        public int? GameTypeId
        {
            get { return _gameTypeId; }
        }

        public int Status
        {
            get { return _status; }
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

        public string CompUrl
        {
            get { return _compUrl; }
        }

        public int SeasonId
        {
            get { return _seasonId; }
        }

        public string DivisionName
        {
            get { return _divisionName; }
        }

        public string SeasonName
        {
            get { return _seasonName; }
        }

        public string HomeNclTeam
        {
            get { return _homeNclTeam; }
        }

        public string AwayNclTeam
        {
            get { return _awayNclTeam; }
        }

        public string HomeTeam
        {
            get { return _homeTeam; }
        }

        public string AwayTeam
        {
            get { return _awayTeam; }
        }

        public string LongHomeTeam
        {
            get { return _longHomeTeam; }
        }

        public string LongAwayTeam
        {
            get { return _longAwayTeam; }
        }
    }
}

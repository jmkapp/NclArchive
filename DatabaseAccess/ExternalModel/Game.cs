using System;

namespace DatabaseAccess.ExternalModel
{
    public class Game
    {
        private readonly int _gameId;
        private readonly Team _homeTeam;
        private readonly Team _awayTeam;
        private readonly int? _homeTeamHtScore;
        private readonly int? _awayTeamHtScore;
        private readonly int _homeTeamScore;
        private readonly int _awayTeamScore;
        private readonly Venue _venue;
        private readonly int? _refereeId;
        private readonly int? _line1Id;
        private readonly int? _line2Id;
        private readonly Division _division;
        private readonly int _compCupPoId;
        private readonly int? _gameTypeId;
        private readonly int _status;
        private readonly DateTime? _gameDate;
        private readonly DateTime? _gameTime;
        private readonly int? _attendance;
        private readonly string _gameMemo;
        private readonly int? _customerId;
        private readonly bool _exactDate;

        public Game(
            int gameId,
            Team homeTeam,
            Team awayTeam,
            int? homeTeamHtScore,
            int? awayTeamHtScore,
            int homeTeamScore,
            int awayTeamScore,
            Venue venue,
            int? refereeId,
            int? line1Id,
            int? line2Id,
            Division division,
            int compCupPoId,
            int? gameTypeId,
            int status,
            DateTime? gameDate,
            DateTime? gameTime,
            int? attendance,
            string gameMemo,
            int? customerId,
            bool exactDate)
        {
            _gameId = gameId;
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _homeTeamHtScore = homeTeamHtScore;
            _awayTeamHtScore = awayTeamHtScore;
            _homeTeamScore = homeTeamScore;
            _awayTeamScore = awayTeamScore;
            _venue = venue;
            _refereeId = refereeId;
            _line1Id = line1Id;
            _line2Id = line2Id;
            _division = division;
            _compCupPoId = compCupPoId;
            _gameTypeId = gameTypeId;
            _status = status;
            _gameDate = gameDate;
            _gameTime = gameTime;
            _attendance = attendance;
            _gameMemo = gameMemo;
            _customerId = customerId;
            _exactDate = exactDate;
        }

        public int GameId => _gameId;

        public Team HomeTeam => _homeTeam;

        public Team AwayTeam => _awayTeam;

        public int? HomeTeamHtScore => _homeTeamHtScore;

        public int? AwayTeamHtScore => _awayTeamHtScore;

        public int HomeTeamScore => _homeTeamScore;

        public int AwayTeamScore => _awayTeamScore;

        public Venue Venue => _venue;

        public int? RefereeId => _refereeId;

        public int? Line1Id => _line1Id;

        public int? Line2Id => _line2Id;

        public Division Division => _division;

        public int CompCupPoId => _compCupPoId;

        public int? GameTypeId => _gameTypeId;

        public int Status => _status;

        public DateTime? GameDate => _gameDate;

        public DateTime? GameTime => _gameTime;

        public int? Attendance => _attendance;

        public string GameMemo => _gameMemo;

        public int? CustomerId => _customerId;

        public bool ExactDate => _exactDate;

        internal static Game Convert(InternalModel.Game game)
        {
            return new Game(
                game.GameId,
                game.HomeTeam == null ? null : Team.Convert(game.HomeTeam),
                game.AwayTeam == null ? null : Team.Convert(game.AwayTeam),
                game.HomeTeamHtScore,
                game.AwayTeamHtScore,
                game.HomeTeamScore,
                game.AwayTeamScore,
                game.Venue == null ? null : Venue.Convert(game.Venue),
                game.RefereeId,
                game.Line1Id,
                game.Line2Id,
                game.Division == null ? null : Division.Convert(game.Division),
                game.CompCupPoId,
                game.GameTypeId,
                game.Status,
                game.GameDate,
                game.GameTime,
                game.Attendance,
                game.GameMemo,
                game.CustomerId,
                game.ExactDate);
        }
    }
}

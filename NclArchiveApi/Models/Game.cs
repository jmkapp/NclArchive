using System;
using DatabaseAccess.ExternalModel.QueryResults;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Game
    {
        [JsonProperty(PropertyName = "gameId")]
        public int GameId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "homeTeam")]
        public Team HomeTeam { get; set; }
        [JsonProperty(PropertyName = "awayTeam")]
        public Team AwayTeam { get; set; }
        [JsonProperty(PropertyName = "homeTeamHtScore")]
        public int? HomeTeamHtScore { get; set; }
        [JsonProperty(PropertyName = "awayTeamHtScore")]
        public int? AwayTeamHtScore { get; set; }
        [JsonProperty(PropertyName = "homeTeamScore")]
        public int HomeTeamScore { get; set; }
        [JsonProperty(PropertyName = "awayTeamScore")]
        public int AwayTeamScore { get; set; }
        [JsonProperty(PropertyName = "refereeId")]
        public int? RefereeId { get; set; }
        [JsonProperty(PropertyName = "line1Id")]
        public int? Line1Id { get; set; }
        [JsonProperty(PropertyName = "line2Id")]
        public int? Line2Id { get; set; }
        [JsonProperty(PropertyName = "gameDate")]
        public DateTime? GameDate { get; set; }
        [JsonProperty(PropertyName = "gameTime")]
        public DateTime? GameTime { get; set; }
        [JsonProperty(PropertyName = "attendance")]
        public int? Attendance { get; set; }
        [JsonProperty(PropertyName = "venue")]
        public Venue Venue { get; set; }
        [JsonProperty(PropertyName = "division")]
        public Division Division { get; set; }
        [JsonProperty(PropertyName = "dDate")]
        public string Ddate { get; set; }
        [JsonProperty(PropertyName = "tTime")]
        public int Ttime { get; set; }
        [JsonProperty(PropertyName = "gameStatus")]
        public string GameStatus { get; set; }
        [JsonProperty(PropertyName = "comp")]
        public string Comp { get; set; }
        [JsonProperty(PropertyName = "compCupPoId")]
        public int CompCupPoId { get; set; }
        [JsonProperty(PropertyName = "gameTypeId")]
        public int? GameTypeId { get; set; }
        [JsonProperty(PropertyName = "season")]
        public Season Season { get; set; }
        [JsonProperty(PropertyName = "memo")]
        public string Memo { get; set; }
        [JsonProperty(PropertyName = "customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty(PropertyName = "exactDate")]
        public bool? ExactDate { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        internal static Game Convert(DatabaseAccess.ExternalModel.Game game)
        {
            Game newGame = new Game();
            newGame.GameId = game.GameId;
            newGame.HomeTeamHtScore = game.HomeTeamHtScore;
            newGame.AwayTeamHtScore = game.AwayTeamHtScore;
            newGame.HomeTeamScore = game.HomeTeamScore;
            newGame.AwayTeamScore = game.AwayTeamScore;
            newGame.RefereeId = game.RefereeId;
            newGame.Line1Id = game.Line1Id;
            newGame.Line2Id = game.Line2Id;
            newGame.CompCupPoId = game.CompCupPoId;
            newGame.GameTypeId = game.GameTypeId;
            newGame.GameStatus = game.Status.ToString();
            newGame.GameDate = game.GameDate;
            newGame.GameTime = game.GameTime;
            newGame.Attendance = game.Attendance;
            newGame.Memo = game.GameMemo;
            newGame.CustomerId = game.CustomerId;
            newGame.ExactDate = game.ExactDate;

            return newGame;
        }

        internal static Game Convert(TeamGameResult result)
        {
            Game game = new Game();
            game.GameId = result.GameId;
            game.ShortName = result.ShortName;
            game.HomeTeamHtScore = result.HomeTeamHtScore;
            game.AwayTeamHtScore = result.AwayTeamHtScore;
            game.HomeTeamScore = result.HomeTeamScore;
            game.AwayTeamScore = result.AwayTeamScore;
            game.GameDate = result.GameDate;
            game.CompCupPoId = result.CompCupPoId;
            game.GameTypeId = result.GameTypeId;
            game.Ddate = result.DDate;
            game.Ttime = result.TTime;
            game.GameStatus = result.GameStatus;
            game.Comp = result.Comp;
            return game;
        }
    }
}
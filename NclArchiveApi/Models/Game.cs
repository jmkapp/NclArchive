using System;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Game
    {
        [JsonProperty(PropertyName = "gameId")]
        public string GameId { get; set; }
        [JsonProperty(PropertyName = "gameType")]
        public string GameType { get; set; }
        [JsonProperty(PropertyName = "gameTypeLink")]
        public string GameTypeLink { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "homeTeam")]
        public Team HomeTeam { get; set; }
        [JsonProperty(PropertyName = "awayTeam")]
        public Team AwayTeam { get; set; }
        [JsonProperty(PropertyName = "homeTeamHtScore")]
        public string HomeTeamHtScore { get; set; }
        [JsonProperty(PropertyName = "awayTeamHtScore")]
        public string AwayTeamHtScore { get; set; }
        [JsonProperty(PropertyName = "homeTeamScore")]
        public string HomeTeamScore { get; set; }
        [JsonProperty(PropertyName = "awayTeamScore")]
        public string AwayTeamScore { get; set; }
        [JsonProperty(PropertyName = "gameDate")]
        public string GameDate { get; set; }
        [JsonProperty(PropertyName = "venueId")]
        public string VenueId { get; set; }
        [JsonProperty(PropertyName = "venueLink")]
        public string VenueLink { get; set; }
        [JsonProperty(PropertyName = "refereeId")]
        public string RefereeId { get; set; }
        [JsonProperty(PropertyName = "refereeLink")]
        public string RefereeLink { get; set; }
        [JsonProperty(PropertyName = "line1Id")]
        public string Line1Id { get; set; }
        [JsonProperty(PropertyName = "line1Link")]
        public string Line1Link { get; set; }
        [JsonProperty(PropertyName = "line2Id")]
        public string Line2Id { get; set; }
        [JsonProperty(PropertyName = "line2Link")]
        public string Line2Link { get; set; }
        [JsonProperty(PropertyName = "divisionId")]
        public string DivisionId { get; set; }
        [JsonProperty(PropertyName = "divisionLink")]
        public string DivisionLink { get; set; }
        [JsonProperty(PropertyName = "compCupPoId")]
        public string CompCupPoId { get; set; }
        [JsonProperty(PropertyName = "gameTypeId")]
        public string GameTypeId { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "dDate")]
        public string Ddate { get; set; }
        [JsonProperty(PropertyName = "tTime")]
        public string Ttime { get; set; }
        [JsonProperty(PropertyName = "gameStatus")]
        public string GameStatus { get; set; }
        [JsonProperty(PropertyName = "comp")]
        public string Comp { get; set; }
        [JsonProperty(PropertyName = "compUrl")]
        public string CompUrl { get; set; }
        [JsonProperty(PropertyName = "season")]
        public Season Season { get; set; }
        [JsonProperty(PropertyName = "seasonLink")]
        public string SeasonLink { get; set; }
        [JsonProperty(PropertyName = "divisionName")]
        public string DivisionName { get; set; }
        [JsonProperty(PropertyName = "homeNclTeam")]
        public string HomeNclTeam { get; set; }
        [JsonProperty(PropertyName = "awayNclTeam")]
        public string AwayNclTeam { get; set; }
        [JsonProperty(PropertyName = "longHomeTeam")]
        public string LongHomeTeam { get; set; }
        [JsonProperty(PropertyName = "longAwayTeam")]
        public string LongAwayTeam { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        internal static Game Convert(DatabaseAccess.ExternalModel.TeamGameResult result)
        {
            Game game = new Game();
            game.GameId = result.GameId;
            game.GameType = result.GameType;
            game.ShortName = result.ShortName;
            game.HomeTeamHtScore = result.HomeTeamHtScore;
            game.AwayTeamHtScore = result.AwayTeamHtScore;
            game.HomeTeamScore = result.HomeTeamScore;
            game.AwayTeamScore = result.AwayTeamScore;
            game.GameDate = result.GameDate;
            game.VenueId = result.VenueId;
            game.RefereeId = result.RefereeId;
            game.Line1Id = result.Line1Id;
            game.Line2Id = result.Line2Id;
            game.DivisionId = result.DivisionId;
            game.CompCupPoId = result.CompCupPoId;
            game.GameTypeId = result.GameTypeId;
            game.Status = result.Status;
            game.Ddate = result.DDate;
            game.Ttime = result.TTime;
            game.GameStatus = result.GameStatus;
            game.Comp = result.Comp;
            game.CompUrl = result.CompUrl;
            game.DivisionName = result.DivisionName;
            game.HomeNclTeam = result.HomeNclTeam;
            game.AwayNclTeam = result.AwayNclTeam;
            game.LongHomeTeam = result.LongHomeTeam;
            game.LongAwayTeam = result.LongAwayTeam;

            return game;
        }
    }
}
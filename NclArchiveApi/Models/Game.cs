using System;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Game
    {
        [JsonProperty(PropertyName = "gameId")]
        public int GameId { get; set; }
        [JsonProperty(PropertyName = "gameType")]
        public int GameType { get; set; }
        [JsonProperty(PropertyName = "gameTypeLink")]
        public string GameTypeLink { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "homeTeamId")]
        public int? HomeTeamId { get; set; }
        [JsonProperty(PropertyName = "homeTeamLink")]
        public string HomeTeamLink { get; set; }
        [JsonProperty(PropertyName = "awayTeamId")]
        public int? AwayTeamId { get; set; }
        [JsonProperty(PropertyName = "awayTeamLink")]
        public string AwayTeamLink { get; set; }
        [JsonProperty(PropertyName = "homeTeamHtScore")]
        public int? HomeTeamHtScore { get; set; }
        [JsonProperty(PropertyName = "awayTeamHtScore")]
        public int? AwayTeamHtScore { get; set; }
        [JsonProperty(PropertyName = "homeTeamScore")]
        public int HomeTeamScore { get; set; }
        [JsonProperty(PropertyName = "awayTeamScore")]
        public int AwayTeamScore { get; set; }
        [JsonProperty(PropertyName = "gameDate")]
        public DateTime GameDate { get; set; }
        [JsonProperty(PropertyName = "venueId")]
        public int VenueId { get; set; }
        [JsonProperty(PropertyName = "venueLink")]
        public string VenueLink { get; set; }
        [JsonProperty(PropertyName = "refereeId")]
        public int? RefereeId { get; set; }
        [JsonProperty(PropertyName = "refereeLink")]
        public string RefereeLink { get; set; }
        [JsonProperty(PropertyName = "line1Id")]
        public int? Line1Id { get; set; }
        [JsonProperty(PropertyName = "line1Link")]
        public string Line1Link { get; set; }
        [JsonProperty(PropertyName = "line2Id")]
        public int? Line2Id { get; set; }
        [JsonProperty(PropertyName = "line2Link")]
        public string Line2Link { get; set; }
        [JsonProperty(PropertyName = "divisionId")]
        public int DivisionId { get; set; }
        [JsonProperty(PropertyName = "divisionLink")]
        public string DivisionLink { get; set; }
        [JsonProperty(PropertyName = "compCupPoId")]
        public int CompCupPoId { get; set; }
        [JsonProperty(PropertyName = "gameTypeId")]
        public int? GameTypeId { get; set; }
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        [JsonProperty(PropertyName = "dDate")]
        public string Ddate { get; set; }
        [JsonProperty(PropertyName = "tTime")]
        public int Ttime { get; set; }
        [JsonProperty(PropertyName = "gameStatus")]
        public string GameStatus { get; set; }
        [JsonProperty(PropertyName = "comp")]
        public string Comp { get; set; }
        [JsonProperty(PropertyName = "compUrl")]
        public string CompUrl { get; set; }
        [JsonProperty(PropertyName = "seasonId")]
        public int seasonId { get; set; }
        [JsonProperty(PropertyName = "seasonLink")]
        public string SeasonLink { get; set; }
        [JsonProperty(PropertyName = "divisionName")]
        public string DivisionName { get; set; }
        [JsonProperty(PropertyName = "seasonName")]
        public string SeasonName { get; set; }
        [JsonProperty(PropertyName = "homeNclTeam")]
        public string HomeNclTeam { get; set; }
        [JsonProperty(PropertyName = "awayNclTeam")]
        public string AwayNclTeam { get; set; }
        [JsonProperty(PropertyName = "homeTeam")]
        public string HomeTeam { get; set; }
        [JsonProperty(PropertyName = "awayTeam")]
        public string AwayTeam { get; set; }
        [JsonProperty(PropertyName = "longHomeTeam")]
        public string LongHomeTeam { get; set; }
        [JsonProperty(PropertyName = "longAwayTeam")]
        public string LongAwayTeam { get; set; }
    }
}
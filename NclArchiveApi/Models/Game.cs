using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Game
    {
        [JsonProperty(PropertyName = "gameId")]
        public string GameId { get; set; }
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
        [JsonProperty(PropertyName = "divisionId")]
        public string DivisionId { get; set; }
        [JsonProperty(PropertyName = "divisionName")]
        public string DivisionName { get; set; }
        [JsonProperty(PropertyName = "dDate")]
        public string Ddate { get; set; }
        [JsonProperty(PropertyName = "tTime")]
        public string Ttime { get; set; }
        [JsonProperty(PropertyName = "gameStatus")]
        public string GameStatus { get; set; }
        [JsonProperty(PropertyName = "comp")]
        public string Comp { get; set; }
        [JsonProperty(PropertyName = "compCupPoId")]
        public string CompCupPoId { get; set; }
        [JsonProperty(PropertyName = "gameTypeId")]
        public string GameTypeId { get; set; }
        [JsonProperty(PropertyName = "season")]
        public Season Season { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        internal static Game Convert(DatabaseAccess.ExternalModel.TeamGameResult result)
        {
            Game game = new Game();
            game.GameId = result.GameId;
            game.ShortName = result.ShortName;
            game.HomeTeamHtScore = result.HomeTeamHtScore;
            game.AwayTeamHtScore = result.AwayTeamHtScore;
            game.HomeTeamScore = result.HomeTeamScore;
            game.AwayTeamScore = result.AwayTeamScore;
            game.GameDate = result.GameDate;
            game.VenueId = result.VenueId;
            game.DivisionId = result.DivisionId;
            game.DivisionName = result.DivisionName;
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
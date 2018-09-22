using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    internal class TeamGameResult
    {
        public int GameType { get; set; }
        public string ShortName { get; set; }
        [Column("GameID")]
        public int GameId { get; set; }
        public int? HomeTeamId { get; set; }
        public int? AwayTeamId { get; set; }
        [Column("HomeTeamHTScore")]
        public int? HomeTeamHtScore { get; set; }
        [Column("AwayTeamHTScore")]
        public int? AwayTeamHtScore { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime GameDate { get; set; }
        [Column("venueid")]
        public int VenueId { get; set; }
        [Column("referee")]
        public int? RefereeId { get; set; }
        [Column("Line1")]
        public int? Line1Id { get; set; }
        [Column("Line2")]
        public int? Line2Id { get; set; }
        [Column("DivisionID")]
        public int DivisionId { get; set; }
        [Column("CompCupPOid")]
        public int CompCupPoId { get; set; }
        [Column("GameTypeid")]
        public int? GameTypeId { get; set; }
        public int Status { get; set; }
        public string DDate { get; set; }
        public int TTime { get; set; }
        public string GameStatus { get; set; }
        public string Comp { get; set; }
        [Column("CompURL")]
        public string CompUrl { get; set; }
        [Column("Seasonid")]
        public int SeasonId { get; set; }
        public string DivisionName { get; set; }
        public string SeasonName { get; set; }
        [Column("HomeNCLteam")]
        public string HomeNclTeam { get; set; }
        [Column("AwayNCLteam")]
        public string AwayNclTeam { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string LongHomeTeam { get; set; }
        public string LongAwayTeam { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    internal class TeamGameResult
    {
        public string ShortName { get; set; }
        [Column("GameID")]
        public int GameId { get; set; }
        public int? HomeTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }
        public int? AwayTeamId { get; set; }
        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }
        [Column("HomeTeamHTScore")]
        public int? HomeTeamHtScore { get; set; }
        [Column("AwayTeamHTScore")]
        public int? AwayTeamHtScore { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime? GameDate { get; set; }
        [Column("venueid")]
        public int VenueId { get; set; }
        [Column("DivisionID")]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string DDate { get; set; }
        public int TTime { get; set; }
        public string GameStatus { get; set; }
        public string Comp { get; set; }
        [Column("CompCupPOid")]
        public int CompCupPoId { get; set; }
        [Column("GameTypeid")]
        public int? GameTypeId { get; set; }
        [Column("Seasonid")]
        public int SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public virtual Season Season { get; set; }
        public string SeasonName { get; set; }
        [Column("HomeTeam")]
        public string HomeTeamName { get; set; }
        [Column("AwayTeam")]
        public string AwayTeamName { get; set; }
    }
}

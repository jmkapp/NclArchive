using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    [Table("dbo.Tbl_Games")]
    internal class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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
        [Column("venueid")]
        public int VenueId { get; set; }
        [Column("Referee")]
        public int? RefereeId { get; set; }
        [Column("Line1")]
        public int? Line1Id { get; set; }
        [Column("Line2")]
        public int? Line2Id { get; set; }
        [Column("DivisionID")]
        public int DivisionId { get; set; }
        [Column("CompCupPOId")]
        public int CompCupPoId { get; set; }
        [Column("GameTypeid")]
        public int? GameTypeId { get; set; }
        public int Status { get; set; }
        public DateTime? GameDate { get; set; }
        public DateTime? GameTime { get; set; }
        public int? Attendance { get; set; }
        public string GameMemo { get; set; }
        [Column("Customerid")]
        public int? CustomerId { get; set; }
        public bool ExactDate { get; set; }
    }
}

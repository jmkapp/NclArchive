using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    [Table("dbo.Tbl_Divisions")]
    internal class Division
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DivisionId { get; set; }
        public string MiniName { get; set; }
        [Column("Shortname")]
        public string ShortName { get; set; }
        [Column("Longname")]
        public string LongName { get; set; }
        public int? CompId { get; set; }
        public int? SeqNo { get; set; }
        public short? Promotions { get; set; }
        public int? PromColor { get; set; }
        public short? Demotions { get; set; }
        public int? DemColor { get; set; }
        public short? PlayOffs { get; set; }
        public int? PlayOffColor { get; set; }
        [Column("PlayOffTypeid")]
        public int? PlayOffTypeId { get; set; }
        public int? PointsWin { get; set; }
        public int? PointsDraw { get; set; }
        [Column("Customerid")]
        public int? CustomerId { get; set; }
        public bool IsGroup { get; set; }
        public string DivisionMemo { get; set; }
        public bool? UseBonusPoints { get; set; }
    }
}

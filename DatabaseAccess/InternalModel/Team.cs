using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    [Table("dbo.Tbl_Teams")]
    internal class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TeamId { get; set; }
        public int? ClubId { get; set; }
        [ForeignKey("ClubId")]
        public virtual Club Club { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string TeamRef { get; set; }
        public short? IsDirty { get; set; }
        public string Url { get; set; }
        public string SponsorsName { get; set; }
        public string SponsorsUrl { get; set; }
        public string MiniName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    [Table("dbo.Tbl_Teams")]
    internal class Team
    {
        public int TeamId { get; set; }
        public Club Club { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string TeamRef { get; set; }
        public short IsDirty { get; set; }
        public string Url { get; set; }
        public string SponsorsName { get; set; }
        public string SponsorsUrl { get; set; }
        public string MiniName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    internal class SeasonsForTeamResult
    {
        [Column("Seasonid")]
        public int SeasonId { get; set; }
        [Column("ShortName")]
        public string ShortName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel.StoredProcedureResults
{
    internal class TeamsInClubResult
    {
        [Column("teamid")]
        public int TeamId { get; set; }
        [Column("Teamname")]
        public string TeamName { get; set; }
        [Column("nclteam")]
        public string NclTeam { get; set; }
        public string LongName { get; set; }
    }
}
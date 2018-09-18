using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.InternalModel
{
    internal class SeasonsForTeamResult
    {
        [Column("ShortName")]
        public string ShortName { get; set; }
        [Column("Seasonid")]
        public string SeasonId { get; set; }
    }
}

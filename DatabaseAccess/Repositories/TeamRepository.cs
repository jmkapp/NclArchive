using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public class TeamRepository
    {
        public async Task<ReadOnlyCollection<ExternalModel.TeamsInClubResult>> GetTeamsInClubAsync(string clubId)
        {
            List<ExternalModel.TeamsInClubResult> teams = new List<ExternalModel.TeamsInClubResult>();

            using (var context = new DatabaseContext())
            {
                var databaseTeams = await context.Database.SqlQuery<InternalModel.TeamsInClubResult>(
                    "dbo.api_GetTeamsinClubID @clubId",
                    new SqlParameter("clubId", int.Parse(clubId))).ToListAsync();

                foreach (InternalModel.TeamsInClubResult team in databaseTeams)
                {
                    ExternalModel.TeamsInClubResult newTeam = new ExternalModel.TeamsInClubResult(
                        team.TeamId.ToString(),
                        team.TeamName,
                        team.NclTeam == "NCL",
                        team.LongName
                    );

                    teams.Add(newTeam);
                }
            }

            return new ReadOnlyCollection<ExternalModel.TeamsInClubResult>(teams);
        }
    }
}
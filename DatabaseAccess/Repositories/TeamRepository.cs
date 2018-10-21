using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DatabaseAccess.Repositories.Interfaces;
using SeasonsForTeamResult = DatabaseAccess.InternalModel.StoredProcedureResults.SeasonsForTeamResult;
using TeamsInClubResult = DatabaseAccess.InternalModel.StoredProcedureResults.TeamsInClubResult;

namespace DatabaseAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public async Task<ExternalModel.Team> GetTeamAsync(string teamReference)
        {
            ExternalModel.Team newTeam = null;

            bool converts = int.TryParse(teamReference, out int teamId);

            if (converts == false)
                return null;

            using (var context = new DatabaseContext())
            {
                InternalModel.Team team = await context.Teams.Include(cl => cl.Club).SingleOrDefaultAsync(tm => tm.TeamId == teamId);

                if (team != null)
                {
                    newTeam = new ExternalModel.Team(
                        team.TeamId,
                        ExternalModel.Club.Convert(team.Club),
                        team.ShortName,
                        team.LongName,
                        team.TeamRef,
                        team.IsDirty.ToString(),
                        team.Url,
                        team.SponsorsName,
                        team.SponsorsUrl,
                        team.MiniName);
                }

                return newTeam;
            }
        }

        public async Task<ReadOnlyCollection<ExternalModel.QueryResults.TeamsInClubResult>> GetTeamsInClubAsync(int clubId)
        {
            List<ExternalModel.QueryResults.TeamsInClubResult> teams = new List<ExternalModel.QueryResults.TeamsInClubResult>();

            using (var context = new DatabaseContext())
            {
                var databaseTeams = await context.Database.SqlQuery<TeamsInClubResult>(
                    "dbo.api_GetTeamsinClubID @clubId",
                    new SqlParameter("clubId", clubId)).ToListAsync();

                foreach (TeamsInClubResult team in databaseTeams)
                {
                    ExternalModel.QueryResults.TeamsInClubResult newTeam = new ExternalModel.QueryResults.TeamsInClubResult(
                        team.TeamId,
                        team.TeamName,
                        team.NclTeam == "NCL",
                        team.LongName
                    );

                    teams.Add(newTeam);
                }
            }

            return new ReadOnlyCollection<ExternalModel.QueryResults.TeamsInClubResult>(teams);
        }

        public async Task<ReadOnlyCollection<ExternalModel.QueryResults.SeasonsForTeamResult>> GetSeasonsForTeamsAsync(string teamReference)
        {
            List<ExternalModel.QueryResults.SeasonsForTeamResult> seasons = new List<ExternalModel.QueryResults.SeasonsForTeamResult>();

            bool converts = int.TryParse(teamReference, out int teamId);

            if (!converts) return null;

            using (var context = new DatabaseContext())
            {
                var databaseSeasons = await context.Database.SqlQuery<SeasonsForTeamResult>(
                    "dbo.api_GetNCLSeasonsForTeamID @teamId",
                    new SqlParameter("teamId", teamId)).ToListAsync();


                foreach (SeasonsForTeamResult season in databaseSeasons)
                {
                    ExternalModel.QueryResults.SeasonsForTeamResult newSeason = new ExternalModel.QueryResults.SeasonsForTeamResult(
                        season.SeasonId,
                        season.ShortName);

                    seasons.Add(newSeason);
                }
            }

            return new ReadOnlyCollection<ExternalModel.QueryResults.SeasonsForTeamResult>(seasons);
        }
    }
}
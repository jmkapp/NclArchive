using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;
using Division = DatabaseAccess.InternalModel.Division;
using Venue = DatabaseAccess.InternalModel.Venue;

namespace DatabaseAccess.Repositories
{
    public class GameRepository : IGameRepository
    {
        public async Task<ReadOnlyCollection<TeamGameResult>> GetGamesAsync(string teamReference,
            string seasonReference)
        {
            List<ExternalModel.TeamGameResult> games = new List<ExternalModel.TeamGameResult>();

            bool teamConverts = int.TryParse(teamReference, out int teamId);
            bool seasonConverts = int.TryParse(seasonReference, out int seasonId);

            if (!teamConverts || !seasonConverts) return null;

            using (var context = new DatabaseContext())
            {
                var databaseGames = await context.Database.SqlQuery<StoredProcedureResults.TeamGameResult>(
                    "dbo.api_GetTeamGames_asc @teamId, @seasonId",
                    new SqlParameter("teamId", teamId),
                    new SqlParameter("seasonId", seasonId)).ToListAsync();

                List<int> teamIds = GetGameIds(databaseGames);
                List<InternalModel.Team> teams = await context.Teams.Where(t => teamIds.Contains(t.TeamId)).ToListAsync();

                InternalModel.Season season = await context.Seasons.FirstOrDefaultAsync(s => s.SeasonId == seasonId);

                List<int> divisionIds = databaseGames.Select(d => d.DivisionId).Distinct().ToList();
                List<Division> divisions =
                    await context.Divisions.Where(d => divisionIds.Contains(d.DivisionId)).ToListAsync();

                List<int> venueIds = databaseGames.Select(v => v.VenueId).Distinct().ToList();
                List<Venue> venues = await context.Venues.Where(v => venueIds.Contains(v.VenueId)).ToListAsync();

                foreach (StoredProcedureResults.TeamGameResult result in databaseGames)
                {
                    Division division = divisions.FirstOrDefault(d => d.DivisionId == result.DivisionId);
                    Venue venue = venues.FirstOrDefault(v => v.VenueId == result.VenueId);

                    TeamGameResult game = new TeamGameResult(
                        result.ShortName,
                        result.GameId.ToString(),
                        result.HomeTeamId.HasValue ? result.HomeTeamId.ToString() : null,
                        Team.Convert(teams.SingleOrDefault(t => t.TeamId == result.HomeTeamId)),
                        result.AwayTeamId.HasValue ? result.AwayTeamId.ToString() : null,
                        Team.Convert(teams.SingleOrDefault(t => t.TeamId == result.AwayTeamId)),
                        result.HomeTeamHtScore.HasValue ? result.HomeTeamHtScore.ToString() : null,
                        result.AwayTeamHtScore.HasValue ? result.AwayTeamHtScore.ToString() : null,
                        result.HomeTeamScore.ToString(),
                        result.AwayTeamScore.ToString(),
                        result.GameDate.HasValue ? result.GameDate.ToString() : null,
                        ExternalModel.Venue.Convert(venue),
                        ExternalModel.Division.Convert(division), 
                        result.DDate,
                        result.TTime.ToString(),
                        result.GameStatus,
                        result.Comp,
                        result.CompCupPoId.ToString(),
                        result.GameTypeId.HasValue ? result.GameTypeId.ToString() : null,
                        result.SeasonId,
                        result.SeasonName,
                        Season.Convert(season),
                        result.HomeTeamName,
                        result.AwayTeamName);
             
                    games.Add(game);
                }
            }

            return new ReadOnlyCollection<TeamGameResult>(games);
        }

        private List<int> GetGameIds(List<StoredProcedureResults.TeamGameResult> results)
        {
            List<int> ids = new List<int>();

            foreach (StoredProcedureResults.TeamGameResult result in results)
            {
                if(result.HomeTeamId.HasValue)
                    ids.Add(result.HomeTeamId.Value);
                if(result.AwayTeamId.HasValue)
                    ids.Add(result.AwayTeamId.Value);
            }

            return ids;
        }
    }
}

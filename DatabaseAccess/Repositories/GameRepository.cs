using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;

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
                var databaseGames = await context.Database.SqlQuery<InternalModel.TeamGameResult>(
                    "dbo.api_GetTeamGames_asc @teamId, @seasonId",
                    new SqlParameter("teamId", teamId),
                    new SqlParameter("seasonId", seasonId)).ToListAsync();

                List<int> teamIds = GetGameIds(databaseGames);
                List<InternalModel.Team> teams = await context.Teams.Where(t => teamIds.Contains(t.TeamId)).ToListAsync();

                InternalModel.Season season = await context.Seasons.FirstOrDefaultAsync(s => s.SeasonId == seasonId);

                foreach (InternalModel.TeamGameResult result in databaseGames)
                {
                    ExternalModel.TeamGameResult game = new TeamGameResult(
                        result.GameType.ToString(),
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
                        result.VenueId.ToString(),
                        result.RefereeId.HasValue ? result.RefereeId.ToString() : null,
                        result.Line1Id.HasValue ? result.Line1Id.ToString() : null,
                        result.Line2Id.HasValue ? result.Line2Id.ToString() : null,
                        result.DivisionId.ToString(),
                        result.CompCupPoId.ToString(),
                        result.GameTypeId.HasValue ? result.GameTypeId.ToString() : null,
                        result.Status.ToString(),
                        result.DDate,
                        result.TTime.ToString(),
                        result.GameStatus,
                        result.Comp,
                        result.CompUrl,
                        result.SeasonId,
                        Season.Convert(season),
                        result.DivisionName,
                        result.SeasonName,
                        result.HomeNclTeam,
                        result.AwayNclTeam,
                        result.HomeTeamName,
                        result.AwayTeamName,
                        result.LongHomeTeam,
                        result.LongAwayTeam);

                    games.Add(game);
                }
            }

            return new ReadOnlyCollection<TeamGameResult>(games);
        }

        private List<int> GetGameIds(List<InternalModel.TeamGameResult> results)
        {
            List<int> ids = new List<int>();

            foreach (InternalModel.TeamGameResult result in results)
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

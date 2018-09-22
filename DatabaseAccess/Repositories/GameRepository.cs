using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                foreach (InternalModel.TeamGameResult result in databaseGames)
                {
                    ExternalModel.TeamGameResult game = new TeamGameResult(
                        result.GameType,
                        result.ShortName,
                        result.GameId,
                        result.HomeTeamId,
                        result.AwayTeamId,
                        result.HomeTeamHtScore,
                        result.AwayTeamHtScore,
                        result.HomeTeamScore,
                        result.AwayTeamScore,
                        result.GameDate,
                        result.VenueId,
                        result.RefereeId,
                        result.Line1Id,
                        result.Line2Id,
                        result.DivisionId,
                        result.CompCupPoId,
                        result.GameTypeId,
                        result.Status,
                        result.DDate,
                        result.TTime,
                        result.GameStatus,
                        result.Comp,
                        result.CompUrl,
                        result.SeasonId,
                        result.DivisionName,
                        result.SeasonName,
                        result.HomeNclTeam,
                        result.AwayNclTeam,
                        result.HomeTeam,
                        result.AwayTeam,
                        result.LongHomeTeam,
                        result.LongAwayTeam);

                    games.Add(game);
                }

                return new ReadOnlyCollection<TeamGameResult>(games);
            }
        }
    }
}

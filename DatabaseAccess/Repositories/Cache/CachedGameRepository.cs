using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;
using DatabaseAccess.ExternalModel.QueryResults;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories.Cache
{
    public class CachedGameRepository : IGameRepository
    {
        private readonly GameRepository _gameRepository;
        private readonly List<CachedTeamGameResult> _teamGameResults;
        private readonly Dictionary<DateTime, Game> _games;

        public CachedGameRepository()
        {
            _gameRepository = new GameRepository();
            _teamGameResults = new List<CachedTeamGameResult>();
            _games = new Dictionary<DateTime, Game>();
        }

        public async Task<Game> GetGameAsync(int gameId)
        {
            Game game = _games.Values.FirstOrDefault(g => g.GameId == gameId);

            if (game == null)
            {
                game = await _gameRepository.GetGameAsync(gameId);

                if(game != null)
                    _games.Add(DateTime.Now, game);
            }

            return game;
        }

        public async Task<ReadOnlyCollection<TeamGameResult>> GetGamesAsync(int teamId, int seasonId)
        {
            CachedTeamGameResult teamGameResult =
                _teamGameResults.FirstOrDefault(tgr => tgr.TeamId == teamId && tgr.SeasonId == seasonId);

            if (teamGameResult == null)
            {
                ReadOnlyCollection<TeamGameResult> teamGameResults = await _gameRepository.GetGamesAsync(teamId, seasonId);

                if (teamGameResults != null)
                {
                    teamGameResult = new CachedTeamGameResult(teamId, seasonId, DateTime.Now, teamGameResults);

                    _teamGameResults.Add(teamGameResult);
                }
            }

            return teamGameResult?.TeamGameResults;
        }
    }
}

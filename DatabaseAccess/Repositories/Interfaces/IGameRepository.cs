using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<ExternalModel.Game> GetGameAsync(int gameId);
        Task<ReadOnlyCollection<TeamGameResult>> GetGamesAsync(int teamId, int seasonId);
    }
}

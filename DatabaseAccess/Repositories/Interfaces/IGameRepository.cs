using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<ReadOnlyCollection<TeamGameResult>> GetGamesAsync(string teamReference, string seasonReference);
    }
}

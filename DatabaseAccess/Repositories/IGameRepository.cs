using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface IGameRepository
    {
        Task<ReadOnlyCollection<ExternalModel.TeamGameResult>> GetGamesAsync(string teamReference, string seasonReference);
    }
}

using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface IClubRepository
    {
        Task<ReadOnlyCollection<ExternalModel.AllClubsResult>> GetAllClubsAsync();
        Task<ExternalModel.Club> GetClubAsync(string clubReference);
    }
}

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface IClubRepository
    {
        Task<ReadOnlyCollection<AllClubsResult>> GetAllClubsAsync();
        Task<ExternalModel.Club> GetClubAsync(int clubReference);
    }
}

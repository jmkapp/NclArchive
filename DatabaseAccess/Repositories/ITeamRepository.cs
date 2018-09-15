using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface ITeamRepository
    {
        Task<ExternalModel.Team> GetTeamAsync(string teamReference);
        Task<ReadOnlyCollection<ExternalModel.TeamsInClubResult>> GetTeamsInClubAsync(string clubId);
    }
}

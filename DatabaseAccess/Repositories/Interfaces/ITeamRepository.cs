using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<ExternalModel.Team> GetTeamAsync(string teamReference);
        Task<ReadOnlyCollection<TeamsInClubResult>> GetTeamsInClubAsync(string clubId);
        Task<ReadOnlyCollection<SeasonsForTeamResult>> GetSeasonsForTeamsAsync(string teamId);
    }
}

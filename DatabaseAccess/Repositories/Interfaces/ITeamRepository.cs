using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<ExternalModel.Team> GetTeamAsync(int teamId);
        Task<ReadOnlyCollection<TeamsInClubResult>> GetTeamsInClubAsync(int clubId);
        Task<ReadOnlyCollection<SeasonsForTeamResult>> GetSeasonsForTeamsAsync(int teamId);
    }
}

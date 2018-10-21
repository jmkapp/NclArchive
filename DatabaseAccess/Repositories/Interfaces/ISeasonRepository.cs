using System.Threading.Tasks;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface ISeasonRepository
    {
        Task<ExternalModel.Season> GetSeasonAsync(int seasonId);
    }
}

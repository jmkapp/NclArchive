using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface ISeasonRepository
    {
        Task<ExternalModel.Season> GetSeasonAsync(int seasonId);
    }
}

using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface IDivisionRepository
    {
        Task<ExternalModel.Division> GetDivisionAsync(int divisionId);
    }
}

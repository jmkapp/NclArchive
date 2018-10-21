using System.Threading.Tasks;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface IDivisionRepository
    {
        Task<ExternalModel.Division> GetDivisionAsync(int divisionId);
    }
}

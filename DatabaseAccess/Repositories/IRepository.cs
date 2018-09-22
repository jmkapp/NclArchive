using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;

namespace DatabaseAccess.Repositories
{
    public interface IRepository<T> where T: IArchiveItem
    {
        Task<T> GetAsync(string id);
    }
}

using System.Threading.Tasks;

namespace DatabaseAccess.Repositories.Interfaces
{
    public interface IVenueRepository
    {
        Task<ExternalModel.Venue> GetVenueAsync(int venueId);
    }
}

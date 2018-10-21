using System.Data.Entity;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        public async Task<Venue> GetVenueAsync(int venueId)
        {
            Venue newVenue = null;

            using (var context = new DatabaseContext())
            {
                InternalModel.Venue venue = await context.Venues.FirstOrDefaultAsync(v => v.VenueId == venueId);

                if (venue != null)
                    newVenue = Venue.Convert(venue);
            }

            return newVenue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories.Cache
{
    public class CachedVenueRepository : IVenueRepository
    {
        private readonly VenueRepository _venueRepository;
        private readonly Dictionary<DateTime, Venue> _venues;

        public CachedVenueRepository()
        {
            _venueRepository = new VenueRepository();
            _venues = new Dictionary<DateTime, Venue>();
        }

        public async Task<Venue> GetVenueAsync(int venueId)
        {
            Venue venue = _venues.Values.FirstOrDefault(v => v.VenueId == venueId);

            if (venue == null)
            {
                venue = await _venueRepository.GetVenueAsync(venueId);

                if(venue != null)
                    _venues.Add(DateTime.Now, venue);
            }

            return venue;
        }
    }
}

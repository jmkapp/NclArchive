using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.Repositories.Interfaces;
using NclArchiveApi.Filters;

namespace NclArchiveApi.Controllers
{
    [BasicAuthentication]
    public class VenueController : ApiController
    {
        private readonly IVenueRepository _venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        [Route("venue/{venueReference}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string venueReference)
        {
            bool converts = int.TryParse(venueReference, out int venueId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Venue databaseVenue = await _venueRepository.GetVenueAsync(venueId);

            if (databaseVenue == null)
                return NotFound();

            Models.Venue venue = Models.Venue.Convert(databaseVenue);

            venue.Link = Url.Content("~/") + "venue/" + databaseVenue.VenueId;

            return Ok(venue);
        }
    }
}

using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.Repositories.Interfaces;

namespace NclArchiveApi.Controllers
{
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
            Authorizer authorizer = new Authorizer(Request.Headers.Authorization);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

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

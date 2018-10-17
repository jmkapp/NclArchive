using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.Repositories;

namespace NclArchiveApi.Controllers
{
    public class SeasonController : ApiController
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonController(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        [Route("season/{seasonReference}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string seasonReference)
        {
            Authorizer authorizer = new Authorizer(Request.Headers.Authorization);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            bool converts = int.TryParse(seasonReference, out int seasonId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Season databaseSeason = await _seasonRepository.GetSeasonAsync(seasonId);

            Models.Season season = Models.Season.Convert(databaseSeason);

            season.Link = Url.Content("~/") + "season/" + databaseSeason.SeasonId;

            return Ok(season);
        }
    }
}

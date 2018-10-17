using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.Repositories;

namespace NclArchiveApi.Controllers
{
    public class DivisionController : ApiController
    {
        private readonly IDivisionRepository _divisionRepository;

        public DivisionController(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        [Route("division/{divisionReference}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string divisionReference)
        {
            Authorizer authorizer = new Authorizer(Request.Headers.Authorization);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            bool converts = int.TryParse(divisionReference, out int divisionId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Division databaseDivision = await _divisionRepository.GetDivisionAsync(divisionId);

            Models.Division division = Models.Division.Convert(databaseDivision);

            division.Link = Url.Content("~/") + "division/" + databaseDivision.DivisionId;

            return Ok(division);
        }
    }
}

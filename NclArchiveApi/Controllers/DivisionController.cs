using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.Repositories.Interfaces;
using NclArchiveApi.Filters;

namespace NclArchiveApi.Controllers
{
    [BasicAuthentication]
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
            bool converts = int.TryParse(divisionReference, out int divisionId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Division databaseDivision = await _divisionRepository.GetDivisionAsync(divisionId);

            if (databaseDivision == null)
                return NotFound();

            Models.Division division = Models.Division.Convert(databaseDivision);

            division.Link = Url.Content("~/") + "division/" + databaseDivision.DivisionId;

            return Ok(division);
        }
    }
}

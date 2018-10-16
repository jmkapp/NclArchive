using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
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
            AuthenticationHeaderValue authenticationHeaderValue = Request.Headers.Authorization;
            var userNamePasswordString = authenticationHeaderValue == null ? ":" :
                Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));

            Authorizer authorizer = new Authorizer(userNamePasswordString);

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

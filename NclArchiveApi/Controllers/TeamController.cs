using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.Repositories;
using NclArchiveApi.Models;

namespace NclArchiveApi.Controllers
{
    public class TeamController : ApiController
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [Route("team/{teamId}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string teamId)
        {
            AuthenticationHeaderValue authenticationHeaderValue = Request.Headers.Authorization;
            var userNamePasswordString = authenticationHeaderValue == null ? ":" :
                Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));

            Authorizer authorizer = new Authorizer(userNamePasswordString);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            DatabaseAccess.ExternalModel.Team databaseTeam = await _teamRepository.GetTeamAsync(teamId);

            if (databaseTeam == null)
                return NotFound();

            Club club = null;
            if (databaseTeam.Club != null)
            {
                club = new Club();
                club.ClubId = databaseTeam.Club.ClubId;
                club.ShortName = databaseTeam.Club.ShortName;
                club.Link = Url.Content("~/") + "club/" + databaseTeam.Club.ClubId;
            }

            Team newTeam = new Team();
            newTeam.TeamId = databaseTeam.TeamId;
            newTeam.Club = club;
            newTeam.ShortName = databaseTeam.ShortName;
            newTeam.LongName = databaseTeam.LongName;
            newTeam.TeamRef = databaseTeam.TeamRef;
            newTeam.IsDirty = databaseTeam.IsDirty;
            newTeam.Url = databaseTeam.Url;
            newTeam.SponsorName = databaseTeam.SponsorsName;
            newTeam.SponsorUrl = databaseTeam.SponsorsUrl;
            newTeam.MiniName = databaseTeam.MiniName;
            newTeam.Link = Url.Content("~/") + "team/" + newTeam.TeamId;

            return Ok(newTeam);
        }
    }
}

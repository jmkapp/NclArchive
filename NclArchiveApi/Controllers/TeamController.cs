using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.ExternalModel.QueryResults;
using DatabaseAccess.Repositories.Interfaces;
using Club = NclArchiveApi.Models.Club;
using Season = NclArchiveApi.Models.Season;
using Team = NclArchiveApi.Models.Team;

namespace NclArchiveApi.Controllers
{
    public class TeamController : ApiController
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [Route("team/{teamReference}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string teamReference)
        {
            Authorizer authorizer = new Authorizer(Request.Headers.Authorization);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            bool converts = int.TryParse(teamReference, out int teamId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Team databaseTeam = await _teamRepository.GetTeamAsync(teamId);

            if (databaseTeam == null)
                return NotFound();

            Club club = null;
            if (databaseTeam.Club != null)
            {
                club = new Club();
                club.ClubId = databaseTeam.Club.ClubId;
                club.ShortName = databaseTeam.Club.ShortName;
                //club.Link = Url.Content("~/") + "club/" + databaseTeam.Club.ClubId;
                club.Link = Url.Content("~/") + "clubx/" + databaseTeam.Club.ClubId;
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
            newTeam.SeasonsLink = Url.Content("~/") + "team/" + newTeam.TeamId + "/seasons";

            return Ok(newTeam);
        }

        [Route("team/{teamReference}/seasons")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> GetSeasons(string teamReference)
        {
            Authorizer authorizer = new Authorizer(Request.Headers.Authorization);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            bool converts = int.TryParse(teamReference, out int teamId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Team databaseTeam = await _teamRepository.GetTeamAsync(teamId);

            if (databaseTeam == null) return NotFound();

            ReadOnlyCollection<SeasonsForTeamResult> seasonsForTeamResults =
                await _teamRepository.GetSeasonsForTeamsAsync(teamId);

            Team team = new Team();
            team.TeamId = databaseTeam.TeamId;
            team.ShortName = databaseTeam.ShortName;
            team.Link = Url.Content("~/") + "team/" + team.TeamId;

            List<Season> seasons = new List<Season>();

            foreach (SeasonsForTeamResult result in seasonsForTeamResults)
            {
                Season newSeason = new Season();

                newSeason.SeasonId = result.SeasonId;
                newSeason.ShortName = result.ShortName;
                newSeason.Link = Url.Content("~/") + "season/" + newSeason.SeasonId;

                seasons.Add(newSeason);
            }

            team.Seasons = seasons;

            return Ok(team);
        }
    }
}

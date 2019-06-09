using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.ExternalModel.QueryResults;
using DatabaseAccess.Repositories.Interfaces;
using NclArchiveApi.Filters;
using NclArchiveApi.Models.Lists;
using Club = NclArchiveApi.Models.Club;

namespace NclArchiveApi.Controllers
{
    [BasicAuthentication]
    public class ClubController : ApiController
    {
        private readonly IClubRepository _clubRepository;
        private readonly ITeamRepository _teamRepository;

        public ClubController(IClubRepository clubRepository, ITeamRepository teamRepository)
        {
            _clubRepository = clubRepository;
            _teamRepository = teamRepository;
        }

        [Route("clubs")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get()
        {
            ReadOnlyCollection<AllClubsResult> clubs = await _clubRepository.GetAllClubsAsync();

            List<Club> newClubs = new List<Club>();

            string baseUrl = Url.Content("~/");

            foreach (AllClubsResult club in clubs)
            {
                Club newClub = new Club();
                newClub.ClubId = club.ClubId;
                newClub.ShortName = club.ShortName;
                newClub.LongName = club.LongName;
                newClub.Link = baseUrl + "club/" + newClub.ClubId;
                newClub.TeamsLink = Url.Content("~/") + "club/" + newClub.ClubId + "/teams";

                newClubs.Add(newClub);
            }

            ClubList clubList = new ClubList();
            clubList.Clubs = newClubs;

            return Ok(clubList);
        }

        [Route("club/{clubReference}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string clubReference)
        {
            bool converts = int.TryParse(clubReference, out int clubId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Club databaseClub = await _clubRepository.GetClubAsync(clubId);

            if (databaseClub == null)
                return NotFound();

            Club newClub = new Club();
            newClub.ClubId = databaseClub.ClubId;
            newClub.ShortName = databaseClub.ShortName;
            newClub.LongName = databaseClub.LongName;
            newClub.Description = databaseClub.Description;
            newClub.Url = databaseClub.Url;
            newClub.ContactName = databaseClub.ContactName;
            newClub.AddressLine1 = databaseClub.AddressLine1;
            newClub.AddressLine2 = databaseClub.AddressLine2;
            newClub.AddressLine3 = databaseClub.AddressLine3;
            newClub.Postcode = databaseClub.Postcode;
            newClub.Telephone = databaseClub.Telephone;
            newClub.Fax = databaseClub.Fax;
            newClub.Link = Url.Content("~/") + "club/" + newClub.ClubId;
            newClub.TeamsLink = Url.Content("~/") + "club/" + newClub.ClubId + "/teams";

            return Ok(newClub);
        }

        [Route("club/{clubReference}/teams")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> GetTeamsInClub(string clubReference)
        {
            bool converts = int.TryParse(clubReference, out int clubId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Club databaseClub = await _clubRepository.GetClubAsync(clubId);

            if (databaseClub == null) return NotFound();

            ReadOnlyCollection<TeamsInClubResult> databaseTeams = await _teamRepository.GetTeamsInClubAsync(clubId);

            Club club = new Club();
            club.ClubId = databaseClub.ClubId;
            club.ShortName = databaseClub.ShortName;
            club.Link = Url.Content("~/") + "club/" + club.ClubId;

            List<Models.Team> newTeams = new List<Models.Team>();

            foreach (TeamsInClubResult team in databaseTeams)
            {
                Models.Team newTeam = new Models.Team();
                newTeam.TeamId = team.TeamId;
                newTeam.ShortName = team.TeamName;
                newTeam.NclTeam = team.NclTeam;
                newTeam.LongName = team.LongName;
                newTeam.Link = Url.Content("~/") + "team/" + newTeam.TeamId;

                newTeams.Add(newTeam);
            }

            club.Teams = newTeams;

            return Ok(club);
        }
    }
}
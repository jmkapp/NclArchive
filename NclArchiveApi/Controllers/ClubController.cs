using DatabaseAccess.Repositories;
using NclArchiveApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.ExternalModel;
using Club = NclArchiveApi.Models.Club;

namespace NclArchiveApi.Controllers
{
    public class ClubController : ApiController
    {
        private readonly string _password = WebConfigurationManager.AppSettings["ApiPassword"];

        [Route("clubs")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            AuthenticationHeaderValue authenticationHeaderValue = Request.Headers.Authorization;
            var userNamePasswordString = authenticationHeaderValue == null ? ":" :
                Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));

            string username = userNamePasswordString.Split(':')[0];
            string password = userNamePasswordString.Split(':')[1];

            if (password != _password)
                return Content(HttpStatusCode.Unauthorized, "Authorization failed for this resource.");

            ClubRepository repository = new ClubRepository();

            ReadOnlyCollection<DatabaseAccess.ExternalModel.AllClubsResult> clubs = repository.GetAllClubs();

            List<Club> newClubs = new List<Club>();

            string baseUrl = Url.Content("~/");

            foreach (DatabaseAccess.ExternalModel.AllClubsResult club in clubs)
            {
                Club newClub = new Club();
                newClub.ClubId = club.ClubId;
                newClub.ShortName = club.ShortName;
                newClub.LongName = club.LongName;
                newClub.Link = baseUrl + "club/" + newClub.ClubId;

                newClubs.Add(newClub);
            }

            ClubList clubList = new ClubList();
            clubList.Clubs = newClubs;

            return Ok(clubList);
        }

        [Route("club/{clubId}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(string clubId)
        {
            AuthenticationHeaderValue authenticationHeaderValue = Request.Headers.Authorization;
            var userNamePasswordString = authenticationHeaderValue == null ? ":" :
                Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));

            string username = userNamePasswordString.Split(':')[0];
            string password = userNamePasswordString.Split(':')[1];

            if (password != _password)
                return Content(HttpStatusCode.Unauthorized, "Authorization failed for this resource.");

            ClubRepository repository = new ClubRepository();

            DatabaseAccess.ExternalModel.Club databaseClub = repository.GetClub(clubId);

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

            TeamRepository teamRepository = new TeamRepository();

            ReadOnlyCollection<DatabaseAccess.ExternalModel.TeamsInClubResult> databaseTeams = teamRepository.GetTeamsInClub(clubId);
            List<Models.Team> newTeams = new List<Models.Team>();

            foreach (DatabaseAccess.ExternalModel.TeamsInClubResult team in databaseTeams)
            {
                Models.Team newTeam = new Models.Team();
                newTeam.TeamId = team.TeamId;
                newTeam.ShortName = team.TeamName;
                newTeam.NclTeam = team.NclTeam ? "true" : "false";
                newTeam.LongName = team.LongName;
                newTeam.Link = Url.Content("~/") + "team/" + newTeam.TeamId;

                newTeams.Add(newTeam);
            }

            newClub.Teams = newTeams;

            return Ok(newClub);
        }
    }
}
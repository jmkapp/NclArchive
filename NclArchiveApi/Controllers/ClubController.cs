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

            ReadOnlyCollection<DatabaseAccess.ExternalModel.Club> clubs = repository.GetAllClubs();

            List<Club> newClubs = new List<Club>();

            string baseUrl = Url.Content("~/");

            foreach (DatabaseAccess.ExternalModel.Club club in clubs)
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
    }
}

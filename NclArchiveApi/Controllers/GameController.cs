using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.ExternalModel;
using DatabaseAccess.Repositories;
using NclArchiveApi.Models;
using Division = NclArchiveApi.Models.Division;
using Season = NclArchiveApi.Models.Season;
using Team = NclArchiveApi.Models.Team;
using Venue = NclArchiveApi.Models.Venue;

namespace NclArchiveApi.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gamerepository)
        {
            _gameRepository = gamerepository;
        }

        [Route("games")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string teamId, string seasonId)
        {
            AuthenticationHeaderValue authenticationHeaderValue = Request.Headers.Authorization;
            var userNamePasswordString = authenticationHeaderValue == null ? ":" :
                Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));

            Authorizer authorizer = new Authorizer(userNamePasswordString);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            ReadOnlyCollection<TeamGameResult> results = await _gameRepository.GetGamesAsync(teamId, seasonId);

            List<Game> games = new List<Game>();

            foreach (TeamGameResult result in results)
            {
                Game game = Game.Convert(result);

                if (result.Season != null)
                {
                    Season season = new Season();
                    season.SeasonId = result.Season.SeasonId;
                    season.ShortName = result.Season.ShortName;
                    season.WinterSeason = null;
                    season.Link = Url.Content("~/") + "season/" + result.Season.SeasonId;

                    game.Season = season;

                }

                if (result.HomeTeam != null)
                {
                    Team homeTeam = new Team();
                    homeTeam.TeamId = result.HomeTeam.TeamId;
                    homeTeam.ShortName = result.HomeTeam.ShortName;
                    homeTeam.Link = Url.Content("~/") + "team/" + result.HomeTeam.TeamId;

                    game.HomeTeam = homeTeam;
                }

                if (result.AwayTeam != null)
                {
                    Team awayTeam = new Team();
                    awayTeam.TeamId = result.AwayTeam.TeamId;
                    awayTeam.ShortName = result.AwayTeam.ShortName;
                    awayTeam.Link = Url.Content("~/") + "team/" + result.AwayTeam.TeamId;

                    game.AwayTeam = awayTeam;
                }

                if (result.Division != null)
                {
                    Division division = new Division();
                    division.DivisionId = result.Division.DivisionId;
                    division.ShortName = result.Division.ShortName;
                    division.Link = Url.Content("~/") + "division/" + result.Division.DivisionId;

                    game.Division = division;
                }

                if (result.Venue != null)
                {
                    Venue venue = new Venue();
                    venue.VenueId = result.Venue.VenueId.ToString();
                    venue.ShortName = result.Venue.ShortName;
                    venue.Link = Url.Content("~/") + "venue/" + result.Venue.VenueId;

                    game.Venue = venue;
                }

                game.Link = Url.Content("~/") + "game/" + result.GameId;
                games.Add(game);
            }

            GameList gameList = new GameList();
            gameList.Games = games;

            return Ok(gameList);
        }
    }
}

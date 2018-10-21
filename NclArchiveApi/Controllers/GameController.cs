using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.ExternalModel.QueryResults;
using DatabaseAccess.Repositories.Interfaces;
using NclArchiveApi.Models.Lists;
using Division = NclArchiveApi.Models.Division;
using Season = NclArchiveApi.Models.Season;
using Team = NclArchiveApi.Models.Team;
using Venue = NclArchiveApi.Models.Venue;
using Game = NclArchiveApi.Models.Game;

namespace NclArchiveApi.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gamerepository)
        {
            _gameRepository = gamerepository;
        }

        [Route("game/{gameReference}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string gameReference)
        {
            Authorizer authorizer = new Authorizer(Request.Headers.Authorization);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            bool converts = int.TryParse(gameReference, out int gameId);

            if (converts == false)
                return BadRequest();

            DatabaseAccess.ExternalModel.Game databaseGame = await _gameRepository.GetGameAsync(gameId);

            if (databaseGame == null)
                return NotFound();

            Game game = Game.Convert(databaseGame);

            if (databaseGame.HomeTeam != null)
            {
                Team newHomeTeam = new Team();
                newHomeTeam.TeamId = databaseGame.HomeTeam.TeamId;
                newHomeTeam.ShortName = databaseGame.HomeTeam.ShortName;
                newHomeTeam.Link = Url.Content("~/") + "team/" + databaseGame.HomeTeam.TeamId;
                game.HomeTeam = newHomeTeam;
            }

            if (databaseGame.AwayTeam != null)
            {
                Team newAwayTeam = new Team();
                newAwayTeam.TeamId = databaseGame.AwayTeam.TeamId;
                newAwayTeam.ShortName = databaseGame.AwayTeam.ShortName;
                newAwayTeam.Link = Url.Content("~/") + "team/" + databaseGame.AwayTeam.TeamId;
                game.AwayTeam = newAwayTeam;
            }

            if (databaseGame.Venue != null)
            {
                Venue newVenue = new Venue();
                newVenue.VenueId = databaseGame.Venue.VenueId;
                newVenue.ShortName = databaseGame.Venue.ShortName;
                newVenue.Link = Url.Content("~/") + "venue/" + databaseGame.Venue.VenueId;
                game.Venue = newVenue;
            }

            if (databaseGame.Division != null)
            {
                Division newDivision = new Division();
                newDivision.DivisionId = databaseGame.Division.DivisionId;
                newDivision.ShortName = databaseGame.Division.ShortName;
                newDivision.Link = Url.Content("~/") + "division/" + databaseGame.Division.DivisionId;
                game.Division = newDivision;
            }

            game.Link = Url.Content("~/") + "game/" + databaseGame.GameId;

            return Ok(game);
        }

        [Route("games")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> Get(string teamId, string seasonId)
        {
            Authorizer authorizer = new Authorizer(Request.Headers.Authorization);

            if (!authorizer.Authorized)
                return Content(HttpStatusCode.Unauthorized, authorizer.RejectionMessage);

            bool teamIdConverts = int.TryParse(teamId, out int teamRef);
            bool seasonIdConverts = int.TryParse(seasonId, out int seasonRef);

            if (teamIdConverts == false || seasonIdConverts == false)
                return BadRequest();

            ReadOnlyCollection<TeamGameResult> results = await _gameRepository.GetGamesAsync(teamRef, seasonRef);

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
                    venue.VenueId = result.Venue.VenueId;
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

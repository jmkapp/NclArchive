using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DatabaseAccess.Repositories;
using NclArchiveApi.Models;

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

            ReadOnlyCollection<DatabaseAccess.ExternalModel.TeamGameResult> results = await _gameRepository.GetGamesAsync(teamId, seasonId);

            List<Game> games = new List<Game>();

            foreach (DatabaseAccess.ExternalModel.TeamGameResult result in results)
            {
                Game game = new Game();
                game.GameId = result.GameId;
                game.GameType = result.GameType;
                game.ShortName = result.ShortName;
                game.HomeTeamId = result.HomeTeamId;
                game.AwayTeamId = result.AwayTeamId;
                game.HomeTeamHtScore = result.HomeTeamHtScore;
                game.AwayTeamHtScore = result.AwayTeamHtScore;
                game.HomeTeamScore = result.HomeTeamScore;
                game.AwayTeamScore = result.AwayTeamScore;
                game.GameDate = result.GameDate;
                game.VenueId = result.VenueId;
                game.RefereeId = result.RefereeId;
                game.Line1Id = result.Line1Id;
                game.Line2Id = result.Line2Id;
                game.DivisionId = result.DivisionId;
                game.CompCupPoId = result.CompCupPoId;
                game.GameTypeId = result.GameTypeId;
                game.Status = result.Status;
                game.Ddate = result.DDate;
                game.Ttime = result.TTime;
                game.GameStatus = result.GameStatus;
                game.Comp = result.Comp;
                game.CompUrl = result.CompUrl;
                game.seasonId = result.SeasonId;
                game.DivisionName = result.DivisionName;
                game.SeasonName = result.SeasonName;
                game.HomeNclTeam = result.HomeNclTeam;
                game.AwayNclTeam = result.AwayNclTeam;
                game.LongHomeTeam = result.LongHomeTeam;
                game.LongAwayTeam = result.LongAwayTeam;

                games.Add(game);
            }

            return Ok(games);
        }
    }
}

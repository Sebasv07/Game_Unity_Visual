using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _GameService;
        public GameController(IGameService gameService)
        {
            _GameService = gameService;
        }


        [HttpGet]
        public async Task<ActionResult<List<GameModel>>> GetAllGames()
        {
            try
            {
                return Ok(await _GameService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{GameId}")]
        public async Task<ActionResult<GameModel>> GetGame(int GameId)
        {
            try
            {
                var game = await _GameService.GetGame(GameId);
                if (game == null)
                {
                    return BadRequest("Game not found");
                }
                return Ok(game);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GameModel>> PostGame(GameModel game)
        {
            try
            {
                var createdGame = await _GameService.CreateGame(game.UserId, game.DateGame, (DateTime)game.StarDate, (DateTime)game.EndDate, (TimeSpan)game.Duration, (int)game.ScenarioId, (int)game.Score, game.Active);
                return CreatedAtAction(nameof(GetGame), new { GameId = createdGame.GameId }, createdGame);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{GameId}")]
        public async Task<ActionResult<GameModel>> DeleteGame(int GameId)
        {
            try
            {
                var deletedGame = await _GameService.DeleteGame(GameId, false);
                if (deletedGame == null)
                {
                    return NotFound("Game not found");
                }
                return Ok(deletedGame);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{GameId}")]
        public async Task<IActionResult> PutGame(int GameId, GameModel game)
        {
            if (GameId != game.GameId)
            {
                return BadRequest();
            }

            try
            {
                var updatedGame = await _GameService.UpdateGame(GameId, game.UserId, game.DateGame, game.StarDate, game.EndDate, game.Duration, game.ScenarioId, game.Score, game.Active);
                return Ok(updatedGame);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ScoreModel>>> GetAllScores()
        {
            try
            {
                var scores = await _scoreService.GetAll();
                return Ok(scores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{ScoreId}")]
        public async Task<ActionResult<ScoreModel>> GetScore(int ScoreId)
        {
            var score = await _scoreService.GetScore(ScoreId);
            if (score == null)
            {
                return BadRequest("Score not found");
            }
            return Ok(score);
        }

        [HttpPost]
        public async Task<ActionResult<ScoreModel>> PostScore(ScoreModel score)
        {
            try
            {
                var createdScore = await _scoreService.CreateScore((int)score.UserId, (int)score.Score, (DateTime)score.DateRegistrer, (int)score.Game, score.Active);
                return CreatedAtAction(nameof(GetScore), new { ScoreId = createdScore.ScoreId }, createdScore);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{ScoreId}")]
        public async Task<IActionResult> PutScore(int ScoreId, ScoreModel score)
        {
            if (ScoreId != score.ScoreId)
            {
                return BadRequest();
            }

            try
            {
                var updatedScore = await _scoreService.UpdateScore(ScoreId, score.UserId, score.Score, score.DateRegistrer, score.Game, score.Active);
                return Ok(updatedScore);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{ScoreId}")]
        public async Task<ActionResult<ScoreModel>> DeleteScore(int ScoreId)
        {
            try
            {
                var deletedScore = await _scoreService.DeleteScore(ScoreId, false);

                if (deletedScore == null)
                {
                    return NotFound();
                }

                return Ok(deletedScore);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

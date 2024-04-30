using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SceneryServiceController : ControllerBase
    {
        private readonly ISceneryService _sceneryService;
        public SceneryServiceController(ISceneryService isceneryService)
        {
            _sceneryService = isceneryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SceneryModel>>> GetAllSceneries()
        {
            try
            {
                return Ok(await _sceneryService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{SceneryId}")]
        public async Task<ActionResult<SceneryModel>> GetScenery(int SceneryId)
        {
            var scenery = await _sceneryService.GetScenery(SceneryId);
            if (scenery == null)
            {
                return BadRequest("Scenery not found");
            }
            return Ok(scenery);
        }

        [HttpPost]
        public async Task<ActionResult<SceneryModel>> PostScenery(SceneryModel scenery)
        {
            try
            {
                var createdScenery = await _sceneryService.CreateScenery(scenery.NameScenery, scenery.DescriptionScenery, (int)scenery.DifficultyLevel, scenery.Location, scenery.CreationDate, scenery.Active);
                return CreatedAtAction(nameof(GetScenery), new { SceneryId = createdScenery.SceneryId }, createdScenery);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{SceneryId}")]
        public async Task<IActionResult> PutScenery(int SceneryId, SceneryModel scenery)
        {
            if (SceneryId != scenery.SceneryId)
            {
                return BadRequest();
            }

            try
            {
                var updatedScenery = await _sceneryService.UpdateScenery(SceneryId, scenery.NameScenery, scenery.DescriptionScenery, scenery.DifficultyLevel, scenery.Location, scenery.CreationDate, scenery.Active);
                return Ok(updatedScenery);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{SceneryId}")]
        public async Task<ActionResult<SceneryModel>> DeleteScenery(int SceneryId)
        {
            try
            {
                var deletedScenery = await _sceneryService.DeleteScenery(SceneryId, false);

                if (deletedScenery == null)
                {
                    return NotFound();
                }

                return Ok(deletedScenery);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}

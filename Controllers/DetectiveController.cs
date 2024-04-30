using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectiveController : ControllerBase
    {
        private readonly IDetectiveService _detectiveService;
        public DetectiveController(IDetectiveService detectiveService)
        {
            _detectiveService = detectiveService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetectiveModel>>> GetAllDetectives()
        {
            try
            {
                return Ok(await _detectiveService.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{detectiveId}")]
        public async Task<ActionResult<DetectiveModel>> GetDetective(int detectiveId)
        {
            var detective = await _detectiveService.GetDetective(detectiveId);
            if (detective == null)
            {
                return BadRequest("Detective not found");
            }
            return Ok(detective);
        }

        [HttpPost]
        public async Task<ActionResult<DetectiveModel>> PostDetective(DetectiveModel detective)
        {
            try
            {
                var createdDetective = await _detectiveService.CreateDetective(detective.NameDetective, detective.Skills, detective.Description, (DateTime)detective.DateCreation, detective.Active);
                return CreatedAtAction(nameof(GetDetective), new { detectiveId = createdDetective.DetectiveId }, createdDetective);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{detectiveId}")]
        public async Task<IActionResult> PutDetective(int detectiveId, DetectiveModel detective)
        {
            if (detectiveId != detective.DetectiveId)
            {
                return BadRequest();
            }

            try
            {
                var updatedDetective = await _detectiveService.UpdateDetective(detectiveId, detective.NameDetective, detective.Skills, detective.Description, detective.DateCreation, detective.Active);
                if (updatedDetective == null)
                {
                    return NotFound(); // El detective no fue encontrado
                }
                return Ok(updatedDetective);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Error interno del servidor
            }
        }

        [HttpDelete("{detectiveId}")]
        public async Task<IActionResult> DeleteDetective(int detectiveId)
        {
            try
            {
                var deletedDetective = await _detectiveService.DeleteDetective(detectiveId, false);
                if (deletedDetective == null)
                {
                    return NotFound(); // El detective no fue encontrado
                }
                return Ok(deletedDetective);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Error interno del servidor
            }
        }

    }
}

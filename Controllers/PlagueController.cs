using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlagueController : ControllerBase
    {
        private readonly IPlagueService _plagueService;
        public PlagueController(IPlagueService plagueService)
        {
            _plagueService = plagueService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlagueModel>>> GetAllPlagues()
        {
            try
            {
                return Ok(await _plagueService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{PlagueId}")]
        public async Task<ActionResult<PlagueModel>> GetPlague(int PlagueId)
        {
            try
            {
                var plague = await _plagueService.GetPlague(PlagueId);
                if (plague == null)
                {
                    return BadRequest("Plague not found");
                }
                return Ok(plague);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<PlagueModel>> PostPlague(PlagueModel plague)
        {
            try
            {
                var createdPlague = await _plagueService.CreatePlague(plague.NamePlague, plague.Description, plague.Active);
                return CreatedAtAction(nameof(GetPlague), new { PlagueId = createdPlague.PlagueId }, createdPlague);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{PlagueId}")]
        public async Task<IActionResult> PutPlague(int PlagueId, PlagueModel plague)
        {
            if (PlagueId != plague.PlagueId)
            {
                return BadRequest("PlagueId mismatch");
            }

            try
            {
                var updatedPlague = await _plagueService.UpdatePlague(PlagueId, plague.NamePlague, plague.Description, plague.Active);
                if (updatedPlague == null)
                {
                    return NotFound("Plague not found");
                }
                return Ok(updatedPlague);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{PlagueId}")]
        public async Task<ActionResult<PlagueModel>> DeletePlague(int PlagueId)
        {
            try
            {
                var deletedPlague = await _plagueService.DeletePlague(PlagueId, false);
                if (deletedPlague == null)
                {
                    return NotFound("Plague not found");
                }
                return Ok(deletedPlague);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

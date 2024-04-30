using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FertilizersController : ControllerBase
    {
        private readonly IFertilizersService _fertilizersService;
        public FertilizersController(IFertilizersService fertilizersService)
        {
            _fertilizersService = fertilizersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FertilizersModel>>> GetAllFertilizers()
        {
            try
            {
                return Ok(await _fertilizersService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{fertilizerId}")]
        public async Task<ActionResult<FertilizersModel>> GetFertilizer(int fertilizerId)
        {
            try
            {
                var fertilizer = await _fertilizersService.GetFertilizers(fertilizerId);
                if (fertilizer == null)
                {
                    return NotFound();
                }
                return Ok(fertilizer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FertilizersModel>> PostFertilizer(FertilizersModel fertilizer)
        {
            try
            {
                var createdFertilizer = await _fertilizersService.CreateFertilizers(fertilizer.NameFertilizert, fertilizer.Description, fertilizer.Active);
                return CreatedAtAction(nameof(GetFertilizer), new { fertilizerId = createdFertilizer.FertilizerId }, createdFertilizer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{fertilizerId}")]
        public async Task<IActionResult> PutFertilizer(int fertilizerId, FertilizersModel fertilizer)
        {
            if (fertilizerId != fertilizer.FertilizerId)
            {
                return BadRequest();
            }

            try
            {
                var updatedFertilizer = await _fertilizersService.UpdateFertilizers(fertilizerId, fertilizer.NameFertilizert, fertilizer.Description);
                return Ok(updatedFertilizer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{fertilizerId}")]
        public async Task<ActionResult<FertilizersModel>> DeleteFertilizer(int fertilizerId)
        {
            try
            {
                var deletedFertilizer = await _fertilizersService.DeleteFertilizers(fertilizerId,false);
                if (deletedFertilizer != null)
                {
                    return Ok(deletedFertilizer);
                }
                else
                {
                    return NotFound(); // Fertilizer not found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal server error
            }
        }


    }
}

using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {
        private readonly ICropService _cropService;
        public CropController(ICropService cropService)
        {
            _cropService = cropService;
        }


        [HttpGet]
        public async Task<ActionResult<List<CropModel>>> GetAllCrops()
        {
            try
            {
                return Ok(await _cropService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Crop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CropModel>> GetCrop(int id)
        {
            var crop = await _cropService.GetCrop(id);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }

        // POST: api/Crop
        [HttpPost]
        public async Task<ActionResult<CropModel>> CreateCrop(CropModel crop)
        {
            try
            {
                var createdCrop = await _cropService.CreateCrop((int)crop.BatchId, (int)crop.UserId, crop.TypeCrop, crop.GreetingStatus, crop.StageGrowth, (int)crop.ClimaticConditionID, (int)crop.SoilQualityID, crop.Active);
                return CreatedAtAction(nameof(GetCrop), new { id = createdCrop.CropId }, createdCrop);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Crop/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCrop(int id, CropModel crop)
        {
            if (id != crop.CropId)
            {
                return BadRequest();
            }

            try
            {
                var updatedCrop = await _cropService.UpdateCrop(id, crop.BatchId, crop.UserId, crop.TypeCrop, crop.GreetingStatus, crop.StageGrowth, crop.ClimaticConditionID, crop.SoilQualityID);
                if (updatedCrop == null)
                {
                    return NotFound();
                }
                return Ok(updatedCrop);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Crop/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop(int id)
        {
            try
            {
                var deletedCrop = await _cropService.DeleteCrop(id, false);
                if (deletedCrop == null)
                {
                    return NotFound();
                }
                return Ok(deletedCrop);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

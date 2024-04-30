using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropPestController : ControllerBase
    {
        private readonly ICropPestService _cropPestService;
        public CropPestController(ICropPestService cropPestService)
        {
            _cropPestService = cropPestService;
        }
        // POST api/CropPest
        [HttpPost]
        public async Task<ActionResult<CropPestsModel>> AddCropPest([FromBody] CropPestsModel cropPestData)
        {
            try
            {
                var createdCropPest = await _cropPestService.CreateCropPest((int)cropPestData.Crop, (int)cropPestData.Plague, cropPestData.Active);
                return CreatedAtAction(nameof(AddCropPest), new { crop = createdCropPest.Crop, plague = createdCropPest.Plague }, createdCropPest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/CropPest/{Crop}/{Plague}
        [HttpDelete("{crop}")]
        public async Task<ActionResult> DeleteCropPest(int crop)
        {
            try
            {
                var deletedCropPest = await _cropPestService.DeleteCropPest(crop, false);
                if (deletedCropPest == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

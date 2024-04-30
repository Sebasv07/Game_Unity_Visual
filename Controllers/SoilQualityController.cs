using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoilQualityController : ControllerBase
    {
        private readonly ISoilQualityService _soilQualityService;

        public SoilQualityController(ISoilQualityService soilQualityService)
        {
            _soilQualityService = soilQualityService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SoilQualityModel>>> GetAllSoilQuality()
        {
            return Ok(await _soilQualityService.GetAll());

        }

        [HttpGet("{SoilQualityId}")]
        public async Task<ActionResult<SoilQualityModel>> GetSoilQuality(int SoilQualityId)
        {
            var SoilQuality = await _soilQualityService.GetSoilQuality(SoilQualityId);
            if (SoilQuality == null)
            {
                return BadRequest("SoilQuality No Fount");
            }
            return Ok(User);

        }

        [HttpPost]
        public async Task<ActionResult<SoilQualityModel>> PostSoilQuality(SoilQualityModel soilQuality)
        {
            try
            {
                var createdSoilQuality = await _soilQualityService.CreateSoilQuality(soilQuality.TypeSoilQuality, soilQuality.NutrientLevel, (int)soilQuality.PH, soilQuality.Description, soilQuality.Active);
                return CreatedAtAction(nameof(GetSoilQuality), new { SoilQualityId = createdSoilQuality.SoilQualityId }, createdSoilQuality);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{SoilQualityId}")]
        public async Task<IActionResult> PutSoilQuality(int SoilQualityId, SoilQualityModel soilQuality)
        {
            if (SoilQualityId != soilQuality.SoilQualityId)
            {
                return BadRequest();
            }

            try
            {
                var updatedSoilQuality = await _soilQualityService.UpdatSoilQuality(SoilQualityId, soilQuality.TypeSoilQuality, soilQuality.NutrientLevel, (int)soilQuality.PH, soilQuality.Description, soilQuality.Active);
                if (updatedSoilQuality == null)
                {
                    return NotFound();
                }
                return Ok(updatedSoilQuality);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{SoilQualityId}")]
        public async Task<ActionResult<SoilQualityModel>> DeleteSoilQuality(int SoilQualityId)
        {
            try
            {
                var deletedSoilQuality = await _soilQualityService.DeleteSoilQuality(SoilQualityId,false);

                if (deletedSoilQuality == null)
                {
                    return NotFound();
                }

                return Ok(deletedSoilQuality);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

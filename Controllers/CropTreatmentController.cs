using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropTreatmentController : ControllerBase
    {
        private readonly ICropTreatmentService _cropTreatmentService;
        public CropTreatmentController(ICropTreatmentService cropTreatmentService)
        {
            _cropTreatmentService = cropTreatmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CropTreatmentModel>>> GetAllCropTreatments()
        {
            try
            {
                return Ok(await _cropTreatmentService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{CropTreatmentId}")]
        public async Task<ActionResult<CropTreatmentModel>> GetCropTreatment(int CropTreatmentId)
        {
            var cropTreatment = await _cropTreatmentService.GetCropTreatment(CropTreatmentId);
            if (cropTreatment == null)
            {
                return BadRequest("CropTreatment Not Found");
            }
            return Ok(cropTreatment);
        }

        [HttpPost]
        public async Task<ActionResult<CropTreatmentModel>> PostCropTreatment(CropTreatmentModel cropTreatment)
        {
            try
            {
                var createdCropTreatment = await _cropTreatmentService.CreateCropTreatment((int)cropTreatment.CropId, (int)cropTreatment.FertilizerId, cropTreatment.TypeTreatment, (DateTime)cropTreatment.DateTreatment, cropTreatment.ProductUsed, (decimal)cropTreatment.QuantityUsed, cropTreatment.ApplicationMethod, cropTreatment.Observations, cropTreatment.Active);
                return CreatedAtAction(nameof(GetCropTreatment), new { CropTreatmentId = createdCropTreatment.CropTreatmentId }, createdCropTreatment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{CropTreatmentId}")]
        public async Task<IActionResult> PutCropTreatment(int CropTreatmentId, CropTreatmentModel cropTreatment)
        {
            if (CropTreatmentId != cropTreatment.CropTreatmentId)
            {
                return BadRequest();
            }

            try
            {
                var updatedCropTreatment = await _cropTreatmentService.UpdateCropTreatment(CropTreatmentId, cropTreatment.CropId, cropTreatment.FertilizerId, cropTreatment.TypeTreatment, cropTreatment.DateTreatment, cropTreatment.ProductUsed, cropTreatment.QuantityUsed, cropTreatment.ApplicationMethod, cropTreatment.Observations);
                return Ok(updatedCropTreatment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{CropTreatmentId}")]
        public async Task<ActionResult<CropTreatmentModel>> DeleteCropTreatment(int CropTreatmentId)
        {
            try
            {
                var deletedCropTreatment = await _cropTreatmentService.DeleteCropTreatment(CropTreatmentId, false);
                if (deletedCropTreatment != null)
                {
                    return Ok(deletedCropTreatment); // Tratamiento de cultivo marcado como inactivo correctamente
                }
                else
                {
                    return NotFound(); // Tratamiento de cultivo no encontrado
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Error interno del servidor
            }
        }


    }
}

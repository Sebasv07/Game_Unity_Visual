using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;   
        }

        [HttpGet]
        public async Task<ActionResult<List<BatchModel>>> GetAllBatches()
        {
            try
            {
                return Ok(await _batchService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{BatchId}")]
        public async Task<ActionResult<BatchModel>> GetBatch(int BatchId)
        {
            try
            {
                var batch = await _batchService.GetBatch(BatchId);
                if (batch == null)
                {
                    return BadRequest("Batch not found");
                }
                return Ok(batch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BatchModel>> CreateBatch(BatchModel batch)
        {
            try
            {
                var createdBatch = await _batchService.CreateBatch(batch.Location, (int)batch.Size, batch.SoilType, batch.Descripcion);
                return CreatedAtAction(nameof(GetBatch), new { BatchId = createdBatch.BachnetId }, createdBatch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{BatchId}")]
        public async Task<IActionResult> UpdateBatch(int BatchId, BatchModel batch)
        {
            if (BatchId != batch.BachnetId)
            {
                return BadRequest();
            }

            try
            {
                var updatedBatch = await _batchService.UpdateBatch(BatchId, batch.Location, batch.Size, batch.SoilType, batch.Descripcion);
                if (updatedBatch == null)
                {
                    return NotFound();
                }
                return Ok(updatedBatch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{BatchId}")]
        public async Task<IActionResult> DeleteBatch(int BatchId)
        {
            try
            {
                var deletedBatch = await _batchService.DeleteBatch(BatchId, false);
                if (deletedBatch == null)
                {
                    return NotFound();
                }
                return Ok(deletedBatch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}

using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectiveCluesController : ControllerBase
    {
        private readonly IDetectiveCluesService _detectiveCluesService;
        public DetectiveCluesController(IDetectiveCluesService detectiveCluesService)
        {
            _detectiveCluesService = detectiveCluesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetectiveCluesModel>>> GetAllDetectiveClues()
        {
            try
            {
                return Ok(await _detectiveCluesService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetectiveCluesModel>> GetDetectiveClues(int id)
        {
            try
            {
                var detectiveClues = await _detectiveCluesService.GetDetectiveClues(id);
                if (detectiveClues == null)
                {
                    return NotFound(); // Devuelve 404 si la pista del detective no se encuentra
                }
                return Ok(detectiveClues); // Devuelve la pista del detective si se encuentra
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Devuelve 500 si hay un error interno del servidor
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetectiveClues(int id, DetectiveCluesModel detectiveClues)
        {
            if (id != detectiveClues.DetectiveCluesId)
            {
                return BadRequest(); // Devuelve 400 si el ID en el cuerpo de la solicitud no coincide con el ID en la ruta
            }

            try
            {
                var updatedDetectiveClues = await _detectiveCluesService.UpdateDetectiveClues(id, detectiveClues.DetectiveId, detectiveClues.Description, detectiveClues.Type, detectiveClues.CollectionDate, detectiveClues.SolutionMistery, detectiveClues.Active);
                if (updatedDetectiveClues == null)
                {
                    return NotFound(); // Devuelve 404 si la pista del detective no se encuentra
                }
                return Ok(updatedDetectiveClues); // Devuelve la pista del detective actualizada si se realizó correctamente
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Devuelve 500 si hay un error interno del servidor
            }


        }

        [HttpPost]
        public async Task<ActionResult<DetectiveCluesModel>> PostDetectiveClues(DetectiveCluesModel detectiveClues)
        {
            try
            {
                var createdDetectiveClues = await _detectiveCluesService.CreateDetectiveClues(detectiveClues.DetectiveId, detectiveClues.Description, detectiveClues.Type, (DateTime)detectiveClues.CollectionDate, (bool)detectiveClues.SolutionMistery, detectiveClues.Active);
                return CreatedAtAction(nameof(GetDetectiveClues), new { id = createdDetectiveClues.DetectiveCluesId }, createdDetectiveClues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetectiveClues(int id)
        {
            try
            {
                var deletedDetectiveClues = await _detectiveCluesService.DeleteDetectiveClues(id,false);
                if (deletedDetectiveClues == null)
                {
                    return NotFound(); // Devuelve 404 si la pista del detective no se encuentra
                }
                return Ok(deletedDetectiveClues); // Devuelve la pista del detective eliminada si se realizó correctamente
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Devuelve 500 si hay un error interno del servidor
            }
        }




    }
}

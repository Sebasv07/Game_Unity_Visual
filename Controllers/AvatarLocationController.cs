using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarLocationController : ControllerBase
    {
        private readonly IAvatarLocationService _avatarLocationService;
        public AvatarLocationController(IAvatarLocationService avatarLocationService)
        {
            _avatarLocationService = avatarLocationService;
        }

        // GET: api/AvatarLocation
        [HttpGet]
        public async Task<ActionResult<List<AvatarLocationModel>>> GetAllAvatarLocations()
        {
            try
            {
                return Ok(await _avatarLocationService.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/AvatarLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvatarLocationModel>> GetAvatarLocation(int id)
        {
            var avatarLocation = await _avatarLocationService.GetAvatarLocation(id);
            if (avatarLocation == null)
            {
                return NotFound();
            }
            return Ok(avatarLocation);
        }

        // POST: api/AvatarLocation
        [HttpPost]
        public async Task<ActionResult<AvatarLocationModel>> CreateAvatarLocation(AvatarLocationModel avatarLocation)
        {
            try
            {
                var createdAvatarLocation = await _avatarLocationService.CreateAvatarLocation(avatarLocation.GameId, avatarLocation.DetectiveId, (decimal)avatarLocation.CoordinatesX, (decimal)avatarLocation.CoordinatesY, (decimal)avatarLocation.CoordinatesZ, avatarLocation.Active);
                return CreatedAtAction(nameof(GetAvatarLocation), new { id = createdAvatarLocation.AvatarLocationId }, createdAvatarLocation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/AvatarLocation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvatarLocation(int id, AvatarLocationModel avatarLocation)
        {
            if (id != avatarLocation.AvatarLocationId)
            {
                return BadRequest();
            }

            try
            {
                var updatedAvatarLocation = await _avatarLocationService.UpdateAvatarLocation(id, avatarLocation.GameId, avatarLocation.DetectiveId, avatarLocation.CoordinatesX, avatarLocation.CoordinatesY, avatarLocation.CoordinatesZ);
                if (updatedAvatarLocation == null)
                {
                    return NotFound();
                }
                return Ok(updatedAvatarLocation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/AvatarLocation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvatarLocation(int id)
        {
            try
            {
                var deletedAvatarLocation = await _avatarLocationService.DeleteAvatarLocation(id, false);
                if (deletedAvatarLocation == null)
                {
                    return NotFound();
                }
                return Ok(deletedAvatarLocation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

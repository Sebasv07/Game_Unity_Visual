using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeCollectionTracksController : ControllerBase
    {
        private readonly ITimeCollectionTrackService _timeCollectionTrackService;

        public TimeCollectionTracksController(ITimeCollectionTrackService timeCollectionTrackService)
        {
            _timeCollectionTrackService = timeCollectionTrackService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeCollectionTracksModel>>> GetAllTimeCollectionTracks()
        {
            return Ok(await _timeCollectionTrackService.GetAll());

        }

        [HttpGet("{TimeCollectionTrackId}")]
        public async Task<ActionResult<TimeCollectionTracksModel>> GetTimeCollectionTrack(int TimeCollectionTrackId)
        {
            var TimeCollectionTrack = await _timeCollectionTrackService.GetTimeCollectionTrack(TimeCollectionTrackId);
            if (TimeCollectionTrack == null)
            {
                return BadRequest("TimeCollectionTrack No Fount");
            }
            return Ok(TimeCollectionTrack);

        }

        [HttpPut("{TimeCollectionTrackId}")]
        public async Task<IActionResult> PutTimeCollectionTracks(int TimeCollectionTrackId, TimeCollectionTracksModel TimeCollectionTrack)
        {
            if (TimeCollectionTrackId != TimeCollectionTrack.TimeCollectionTracksId)
            {
                return BadRequest();
            }

            try
            {
                var updatedTimeCollectionTrack = await _timeCollectionTrackService.UpdateTimeCollectionTrack(TimeCollectionTrackId, TimeCollectionTrack.DetectiveId, TimeCollectionTrack.GameId, TimeCollectionTrack.DetectiveCluesId, TimeCollectionTrack.TimeClues, TimeCollectionTrack.Active);
                return Ok(updatedTimeCollectionTrack);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{TimeCollectionTrackId}")]
        public async Task<ActionResult<TimeCollectionTracksModel>> DeleteTimeCollectionTrack(int TimeCollectionTrackId)
        {
            try
            {
                var deletedTimeCollectionTrack = await _timeCollectionTrackService.DeleteGetTimeCollectionTrack(TimeCollectionTrackId, false);
                if (deletedTimeCollectionTrack != null)
                {
                    return Ok(deletedTimeCollectionTrack);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimeCollectionTracksModel>> PostTimeCollectionTrack(TimeCollectionTracksModel TimeCollectionTrack)
        {
            try
            {
                var createdTimeCollectionTrack = await _timeCollectionTrackService.CreateTimeCollectionTrack(TimeCollectionTrack.DetectiveId, TimeCollectionTrack.GameId, TimeCollectionTrack.DetectiveCluesId, (DateTime)TimeCollectionTrack.TimeClues, TimeCollectionTrack.Active);
                return CreatedAtAction(nameof(GetTimeCollectionTrack), new { TimeCollectionTrackId = createdTimeCollectionTrack.TimeCollectionTracksId }, createdTimeCollectionTrack);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




    }
}

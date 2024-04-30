using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathercontitionsController : ControllerBase
    {
        private readonly IWeathercontitionService _weathercontitionService;
        public WeathercontitionsController(IWeathercontitionService weathercontitionService)
        {
            _weathercontitionService = weathercontitionService;
        }


        [HttpGet]
        public async Task<ActionResult<List<WeathercontitionsModel>>> GetAllWeathercontition()
        {
            try
            {
                return Ok(await _weathercontitionService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{WeathercontitionsID}")]
        public async Task<ActionResult<WeathercontitionsModel>> GetWeathercontition(int WeathercontitionsID)
        {
            try
            {
                var Weathercontitions = await _weathercontitionService.GetWeathercontitions(WeathercontitionsID);
                if (Weathercontitions == null)
                {
                    return BadRequest("Weathercontitions not found");
                }
                return Ok(Weathercontitions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<WeathercontitionsModel>> PostWeathercontition(WeathercontitionsModel weathercontition)
        {
            try
            {
                var createdWeathercontition = await _weathercontitionService.CreateWeathercontitions(weathercontition.TypeWeather, weathercontition.Description, (bool)weathercontition.Active);
                return CreatedAtAction(nameof(GetAllWeathercontition), new { WeathercontitionsID = createdWeathercontition.WeatherContitionId }, createdWeathercontition);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{WeathercontitionsID}")]
        public async Task<IActionResult> PutWeathercontition(int WeathercontitionsID, WeathercontitionsModel weathercontition)
        {
            if (WeathercontitionsID != weathercontition.WeatherContitionId)
            {
                return BadRequest();
            }

            try
            {
                var updatedWeathercontition = await _weathercontitionService.UpdateWeathercontitions(WeathercontitionsID, weathercontition.TypeWeather, weathercontition.Description);
                return Ok(updatedWeathercontition);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{WeathercontitionsID}")]
        public async Task<ActionResult<WeathercontitionsModel>> DeleteWeathercontition(int WeathercontitionsID)
        {
            try
            {
                var deletedWeathercontition = await _weathercontitionService.DeleteWeathercontitions(WeathercontitionsID, false);
                if (deletedWeathercontition != null)
                {
                    return Ok(deletedWeathercontition);
                }
                else
                {
                    return NotFound(); // Weather condition not found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal s


            }
        }

    }
}
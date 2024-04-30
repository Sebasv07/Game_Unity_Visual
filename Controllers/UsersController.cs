using Game_Unity.Context;
using Game_Unity.Models;
using Game_Unity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUser()
        {
            return Ok(await _userService.GetAll());

        }

        [HttpGet("{UserId}")]
        public async Task<ActionResult<UserModel>> GetUser(int UserId)
        {
            var User = await _userService.GetUser(UserId);
            if (User == null)
            {
                return BadRequest("User No Fount");
            }
            return Ok(User);

        }

        [HttpPut("{UserId}")]
        public async Task<IActionResult> PutUser(int UserId, UserModel user)
        {
            if (UserId != user.UserId)
            {
                return BadRequest();
            }

            try
            {
                var updatedUser = await _userService.UpdateUser(UserId, user.NameUser, user.Password, user.EMail, user.Level, user.Experience, user.Score, user.RegistrationDate, user.Departure, user.Active);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            try
            {
                var createdUser = await _userService.CreateUser(user.NameUser, user.Password, user.EMail, (int)user.Level, (int)user.Experience, (int)user.Score, (DateTime)user.RegistrationDate, (int)user.Departure, user.Active = true);
                return CreatedAtAction(nameof(GetUser), new { UserId = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{UserId}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int UserId)
        {
            try
            {
                var deletedUser = await _userService.DeleteUser(UserId, false); // Llama al método DeleteUser del servicio
                if (deletedUser != null)
                {
                    return Ok(deletedUser); // Usuario marcado como inactivo correctamente
                }
                else
                {
                    return NotFound(); // Usuario no encontrado
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Error interno del servidor
            }
        }

    }

}

using Register_API.Model;
using Microsoft.AspNetCore.Mvc;
using Register_API.Model.Repository;

namespace Register_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserRepository userRepository = new UserRepository();

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            try
            {
                userRepository.AddUser(user);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}

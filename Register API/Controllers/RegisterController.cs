using Register_API.Model;
using Microsoft.AspNetCore.Mvc;
using Register_API.Model.Repository;
using Register_API.Model;
using Register_API.Model.payload;

namespace Register_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserRepository _userRepository; // Assuming you have a user repository or service to interact with users

        public RegisterController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //http
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestModel registerModel)
        {  
            //// Check if the user already exists
            //if (_userRepository.UserExists(registerModel.Username, registerModel.Email))
            //{
            //    return Conflict("User already exists.");
            //}

            // Perform actual registration
            try
            {
                 _userRepository.RegisterUser(registerModel);

                // Additional steps like sending confirmation emails, setting up user profiles, etc., can be done here

                return Ok("Registration successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Registration failed: {ex.Message}");
            }
        }
    }
}

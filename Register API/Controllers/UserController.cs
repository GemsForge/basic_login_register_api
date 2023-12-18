using Microsoft.AspNetCore.Mvc;
using Register_API.Model.Repository;
using Register_API.Model.payload;

namespace Register_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository; // Assuming you have a user repository or service to interact with users

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //http
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestModel registerModel)
        {
            //// TODO: Check if the user already exists
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

        [HttpPost("login")]
        public IActionResult Login(LoginRequestModel model)
        {
            // Validate model and perform necessary checks
            bool isAuthenticated = _userRepository.AuthenticateUser(model);

            if (isAuthenticated)
            {
                return Ok($"Login successful! Welcome,  {model.Username}");
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }

        }
    }
}

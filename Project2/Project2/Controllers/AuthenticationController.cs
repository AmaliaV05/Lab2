using Microsoft.AspNetCore.Mvc;
using Project2.Services;
using Project2.ViewModels.Authentication;

using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthManagementService _authenticationService;

        public AuthenticationController(IAuthManagementService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Create new user through registration
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns>Ok if registration is successfull, Bad Request if not</returns>
        [HttpPost]
        [Route("register")] //api/authentication/register
        public async Task<ActionResult> RegisterUser(RegisterRequest registerRequest)
        {
            var registerServiceResult = await _authenticationService.RegisterUser(registerRequest);
            if (registerServiceResult.ResponseError != null)
            {
                return BadRequest(registerServiceResult.ResponseError);
            }

            return Ok(registerServiceResult.ResponseOk);
        }


        /// <summary>
        /// Confirm new user creation
        /// </summary>
        /// <param name="confirmUserRequest"></param>
        /// <returns>Ok if confirmation is successfull, Bad Request if not</returns>
        [HttpPost]
        [Route("confirm")]
        public async Task<ActionResult> ConfirmUser(ConfirmUserRequest confirmUserRequest)
        {
            var serviceResult = await _authenticationService.ConfirmUserRequest(confirmUserRequest);
            if (serviceResult)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Request user login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>Returns Ok if user successfully logged in, else Unauthorized</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            var serviceResult = await _authenticationService.LoginUser(loginRequest);
            if (serviceResult.ResponseOk != null)
            {
                return Ok(serviceResult.ResponseOk);
            }

            return Unauthorized();
        }
    }
}

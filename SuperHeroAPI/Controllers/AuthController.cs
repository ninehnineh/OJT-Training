using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Dtos.User;
using SuperHeroAPI.Models;
using SuperHeroAPI.Repository;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices AuthServices;

        public AuthController(IAuthServices authServices)
        {
            AuthServices = authServices;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponses<int>>> Register (UserRegisterDto request)
        {
            var response = await AuthServices.Register(
                 new User { Userame = request.Username}, request.Password
                );
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}

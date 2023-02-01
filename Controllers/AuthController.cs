using Auth_API.Domain.Entities.Dtos;
using Auth_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        public IConfiguration _configuration { get; set; }
        public AuthService _authService { get; set; }
        public AuthController(IConfiguration configuration, AuthService authService) 
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserInputDto inputDto)
        {
            try
            {
                await _authService.RegisterUser(inputDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto inputDto)
        {
            try
            {
                var id = await _authService.LogIn(inputDto);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

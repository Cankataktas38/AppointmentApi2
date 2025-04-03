using AppointmentApi.Models;
using AppointmentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
       private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                PasswordHash = model.Password
            };
            if (_authService.Register(user))
                return Ok("Kullanıcı oluşturuldu");
            return BadRequest("Kullanıcı oluşturulamadı");
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                PasswordHash = model.Password
            };
            var token = _authService.Authenticate(user);
            if (token != null)
                return Ok(new {Token = token});
            return Unauthorized("Geçersiz kullanıcı adı veya şifre");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskPractice.Data.dto;
using TaskPractice.Services;

namespace TaskPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin login;

        public LoginController(ILogin login)
        {
            this.login = login;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> register(dto_Register dto_Register)
        {
            return await login.RegisterAsync(dto_Register);
        }
    }
}
    
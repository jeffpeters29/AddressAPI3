using AddressAPI3.Application.User;
using AddressAPI3.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AddressAPI3.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User userParam)
        {
            var referer = this.Request.Headers["Referer"].ToString();

            var user = _userService.Authenticate(userParam.Username, userParam.Password, userParam.Referer);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
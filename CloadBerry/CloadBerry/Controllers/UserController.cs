using CloadBerry.Attributes;
using CloadBerry.Models;
using CloadBerry.Models.DTO;
using CloadBerry.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloadBerry.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)

        {
            _userService = userService;
        }
        [SkipAuth]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {

            if (ModelState.IsValid)
            {
                var result = await _userService.Login(login);
                if (result == null)
                {
                    return NotFound();
                }
                else
                    return Ok(result);

            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpGet("me")]
        public CurrentUserDTO Me() => _userService.Me();
        [HttpPut("ChangePassword")]
        public async Task<ActionResult> ChangePassword(String Password, string NewPassword)
        {
            var user = await _userService.ChangePassword(Password, NewPassword);
            if (user)
                return Ok();
            return NotFound();
        }
        [SkipAuth]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Add(model);
                if (user)
                    return CreatedAtAction(nameof(Register), null);
                else
                    return BadRequest();
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}

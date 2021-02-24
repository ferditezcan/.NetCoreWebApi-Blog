using Blog.Bussines.Abstract;
using Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("test")]
        public IActionResult Login(string username,string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var result = _userService.Login(username, password);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Kullanıcı adı ya da şifre yanlış.");

            }
           
            return NotFound();
        }
    }
}

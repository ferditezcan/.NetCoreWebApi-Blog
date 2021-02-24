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
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users); //200 + data
        }
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")] //api/hotels/gethotelbyid/2     Route ile istediğimiz kadar request yazabiliriz
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user); //200 + data
            }
            return NotFound(); // 404
        }

       
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser); //201 + data
        }
      
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] User User)
        {
            if (await _userService.GetUserById(User.Id) != null)
            {
                return Ok(await _userService.UpdateUser(User));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userService.GetUserById(id) != null)
            {
                await _userService.DeleteUser(id);
                return Ok(); //200
            }
            return NotFound();
        }

    }
}


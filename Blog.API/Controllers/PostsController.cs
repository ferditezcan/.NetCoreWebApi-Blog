using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities;
using Blog.Bussines.Abstract;
using Blog.Bussines.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.DataAccess.Abstract;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts); //200 + data
        }
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")] //api/hotels/gethotelbyid/2     Route ile istediğimiz kadar request yazabiliriz
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.GetPostById(id);
            if (post != null)
            {
                return Ok(post); //200 + data
            }
            return NotFound(); // 404
        }

        //[HttpGet]
        //[Route("[action]/{name}")] //api/hotels/gethotelbyid/name
        //public async Task<IActionResult> GetPostByName(string name)
        //{
        //    var post = await _postService.GetPostByName(name);
        //    if (post != null)
        //    {
        //        return Ok(post); //200 + data
        //    }
        //    return NotFound(); // 404
        //}

        /// <summary>
        /// Create the hotel
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePost([FromBody]Post post)
        {
            var createdPost = await _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost); //201 + data
        }
        /// <summary>
        /// Update the hotel
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody]Post post)
        {
            if (await _postService.GetPostById(post.Id) != null)
            {
                return Ok(await _postService.UpdatePost(post));
            }
            return NotFound();
        }
        /// <summary>
        /// Delete the hotel
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (await _postService.GetPostById(id) != null)
            {
                await _postService.DeletePost(id);
                return Ok(); //200
            }
            return NotFound();
        }
    }
}

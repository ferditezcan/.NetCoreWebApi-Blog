using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bussines.Abstract
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        //Task<Post> GetHotelByName(string name);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task DeletePost(int id);
    }
}

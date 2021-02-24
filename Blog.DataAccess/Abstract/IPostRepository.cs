using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPosts();

        Task<Post> GetPostById(int id);

        Task<Post> CreatePost(Post post);

        Task<Post> UpdatePost(Post post);

        Task DeletePost(int id);

        //Task<Hotel> GetPostByName(string name);
    }
}

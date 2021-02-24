using Blog.Entities;
using Blog.Bussines.Abstract;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Bussines.Concrete
{
    public class PostManager : IPostService
    {

        private IPostRepository _postRepository;

        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        public async Task<Post> CreatePost(Post post)
        {
          
            return await _postRepository.CreatePost(post);
        }

        public async Task DeletePost(int id)
        {
            await _postRepository.DeletePost(id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task<Post> GetPostById(int id)
        {
            if (id > 0)
            {
                return await _postRepository.GetPostById(id);
            }
            throw new Exception("id cannot be less then 1");
        }

        public async Task<Post> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }
    }
}

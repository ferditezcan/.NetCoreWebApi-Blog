using Blog.Entities;
using Blog.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class PostRepository : IPostRepository
    {
        public async Task<Post> CreatePost(Post post)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Posts.Add(post);
                await hotelDbContext.SaveChangesAsync();
                return post;
            }
        }

        public async Task<Post> UpdatePost(Post post)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Posts.Update(post);
                await hotelDbContext.SaveChangesAsync();
                return post;
            }
        }

        public async Task DeletePost(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletedPost = await GetPostById(id);
                hotelDbContext.Posts.Remove(deletedPost);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPosts()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Posts.ToListAsync();
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Posts.FindAsync(id);
            }
        }

        //public async Task<Post> GetPostByName(string name)
        //{
        //    using (var hotelDbContext = new HotelDbContext())
        //    {
        //        return await hotelDbContext.Posts.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        //    }
        //}
    }
}

using Blog.DataAccess.Abstract;
using Blog.Entities;
using Blog.Model.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Users.Add(user);
                await hotelDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Users.Update(user);
                await hotelDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletedUser = await GetUserById(id);
                hotelDbContext.Users.Remove(deletedUser);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Users.ToListAsync();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Users.FindAsync(id);
            }
        }
        public UserModel Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                using (var hotelDbContext = new HotelDbContext())
                {
                    var result = hotelDbContext.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                    if (result != null)
                    {
                        var userModel = new UserModel()
                        {
                            Id = result.Id,
                            Mail = result.EMail,
                            Password = result.Password,
                            Username = result.UserName
                        };
                        return userModel;
                    }

                    return new UserModel();
                }
            }
            return new UserModel();
        }
    }
}

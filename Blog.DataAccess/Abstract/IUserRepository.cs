
using Blog.Entities;
using Blog.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();

        Task<User> GetUserById(int id);

        Task<User> CreateUser(User user);

        Task<User> UpdateUser(User user);

        Task DeleteUser(int id);
        UserModel Login(string username, string password);
    }
}

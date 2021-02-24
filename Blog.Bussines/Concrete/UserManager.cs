using Blog.Bussines.Abstract;
using Blog.DataAccess.Abstract;
using Blog.Entities;
using Blog.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bussines.Concrete
{
    public class UserManager:IUserService
    {

        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {

            return await _userRepository.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUser();;
        }

        public async Task<User> GetUserById(int id)
        {
            if (id > 0)
            {
                return await _userRepository.GetUserById(id);
            }
            throw new Exception("id cannot be less then 1");
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
        public UserModel Login(string username,string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return _userRepository.Login(username, password);
                
            }
            return new UserModel();
        }
    }
}


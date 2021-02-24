using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.User
{
    public class UserModel
    {
        public int Id{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}

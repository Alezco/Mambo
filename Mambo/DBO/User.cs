using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(int roleId, string pseudo, string email, string password)
        {
            RoleId = roleId;
            Pseudo = pseudo;
            Email = email;
            Password = password;
        }
    }
}
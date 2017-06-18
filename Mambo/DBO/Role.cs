using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public Role() { }
        
        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public Role(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }

        public bool isEqual(Role r2)
        {
            return this.RoleName == r2.RoleName;
        }
    }
}
using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class Role : ICrud<DBO.Role>
    {
        private DataAccess.Role roleAccess;
        public Role()
        {
            roleAccess = new DataAccess.Role();
        }

        public bool Create(DBO.Role obj)
        {
            return roleAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return roleAccess.Delete(key);
        }

        public DBO.Role Get(int key)
        {
            return roleAccess.Get(key);
        }

        public List<DBO.Role> GetAll()
        {
            return roleAccess.GetAll();
        }

        public bool Update(DBO.Role obj)
        {
            return roleAccess.Update(obj);
        }
    }
}
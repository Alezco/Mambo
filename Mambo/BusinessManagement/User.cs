using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class User : ICrud<DBO.User>
    {
        private DataAccess.User userAccess;
        public User()
        {
            userAccess = new DataAccess.User();
        }

        public bool Create(DBO.User obj)
        {
            return userAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return userAccess.Delete(key);
        }

        public DBO.User Get(int key)
        {
            return userAccess.Get(key);
        }

        public DBO.User GetByEmail(string email)
        {
            return userAccess.GetByEmail(email);
        }

        public List<DBO.User> GetAll()
        {
            return userAccess.GetAll();
        }

        public bool Update(DBO.User obj)
        {
            return userAccess.Update(obj);
        }
    }
}
using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;
using System.Diagnostics;

namespace Mambo.DataAccess
{
    public class User : ICrud<DBO.User>
    {
        public bool Create(DBO.User obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.CreateUser(obj.Pseudo, obj.Email, obj.Password, obj.RoleId).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("User Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }

        public bool Delete(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.DeleteUser(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("User Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }

        public DBO.User Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetUser(key).FirstOrDefault();
                    return new DBO.User(result.id, result.roleID, result.pseudo, result.email, result.password);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("User Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public DBO.User GetByEmail(string email)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.T_USER.Where(x => x.email == email).FirstOrDefault();
                    return new DBO.User(result.id, result.roleID, result.pseudo, result.email, result.password);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("User Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<DBO.User> GetAll()
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_USER> tUsers = bdd.T_USER.ToList();
                    List<DBO.User> users = new List<DBO.User>();
                    foreach (T_USER tUser in tUsers)
                    {
                        DBO.User user = new DBO.User(tUser.id, tUser.roleID, tUser.pseudo, tUser.email, tUser.password);
                        users.Add(user);
                    }
                    return users;
                }
            }

            catch (Exception exception)
            {
                Debug.WriteLine("User Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public bool Update(DBO.User obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateUser(obj.Id, obj.Pseudo, obj.Email, obj.Password, obj.RoleId).FirstOrDefault();
                    return req != null && obj.isEqual(new DBO.User(req.roleID, req.pseudo, req.email, req.password));
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("User Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }
    }
}
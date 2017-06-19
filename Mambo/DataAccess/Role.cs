using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;
using System.Diagnostics;

namespace Mambo.DataAccess
{
    public class Role : ICrud<DBO.Role>
    {
        public bool Create(DBO.Role obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.CreateRole(obj.RoleName).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Role Exception");
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
                    long result = bdd.DeleteRole(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Role Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }

        public DBO.Role Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetRole(key).FirstOrDefault();
                    return new DBO.Role(result.id, result.role);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Role Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<DBO.Role> GetAll()
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_ROLE> tRoles = bdd.T_ROLE.ToList();
                    List<DBO.Role> roles = new List<DBO.Role>();
                    foreach (T_ROLE tRole in tRoles)
                    {
                        DBO.Role role = new DBO.Role(tRole.id, tRole.role);
                        roles.Add(role);
                    }
                    return roles;
                }
            }

            catch (Exception exception)
            {
                Debug.WriteLine("Role Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public bool Update(DBO.Role obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateRole(obj.Id, obj.RoleName).FirstOrDefault();
                    return obj.isEqual(new DBO.Role(req));
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Role Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class Resources
    {
        private DataAccess.Resources resourcesAccess;
        public Resources()
        {
            resourcesAccess = new DataAccess.Resources();
        }

        public int Create(DBO.Resources obj)
        {
            return resourcesAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return resourcesAccess.Delete(key);
        }

        public bool DeleteResourceLink(int key)
        {
            return resourcesAccess.DeleteResourceLink(key);
        }
             
        public DBO.Resources Get(int key)
        {
            return resourcesAccess.Get(key);
        }

        public List<DBO.Resources> GetAll()
        {
            return resourcesAccess.GetAll();
        }

        public bool Update(DBO.Resources obj, DBO.Article article)
        {
            return resourcesAccess.Update(obj, article);
        }

    }
}
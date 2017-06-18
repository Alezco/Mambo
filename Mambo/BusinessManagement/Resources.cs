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

        public bool Create(DBO.Resources obj, DBO.Article article)
        {
            return resourcesAccess.Create(obj, article);
        }

        public bool Delete(int key)
        {
            return resourcesAccess.Delete(key);
        }

        public DBO.Resources Get(int key)
        {
            return resourcesAccess.Get(key);
        }

        public List<DBO.Resources> GetAll()
        {
            return resourcesAccess.GetAll();
        }

        public bool Update(DBO.Resources obj)
        {
            return resourcesAccess.Update(obj);
        }

    }
}
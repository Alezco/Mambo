using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class Article
    {
        private DataAccess.Article articleAccess;
        public Article()
        {
            articleAccess = new DataAccess.Article();
        }

        public bool Create(DBO.Article obj)
        {
            return articleAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return articleAccess.Delete(key);
        }

        public DBO.Article Get(int key)
        {
            return articleAccess.Get(key);
        }

        public List<DBO.Article> GetAll()
        {
            return articleAccess.GetAll();
        }

        public bool Update(DBO.Article obj, DBO.Resources resources)
        {
            return articleAccess.Update(obj, resources);
        }

    }
}
using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class ArticleLike : ICrud<DBO.ArticleLike>
    {
        private DataAccess.ArticleLike articleLikeAccess;
        public ArticleLike()
        {
            articleLikeAccess = new DataAccess.ArticleLike();
        }

        public bool Create(DBO.ArticleLike obj)
        {
            return articleLikeAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return articleLikeAccess.Delete(key);
        }

        public DBO.ArticleLike Get(int key)
        {
            return articleLikeAccess.Get(key);
        }

        public List<DBO.ArticleLike> GetAll()
        {
            return articleLikeAccess.GetAll();
        }

        public bool Update(DBO.ArticleLike obj)
        {
            return articleLikeAccess.Update(obj);
        }

        public int CountLikesByArticleId(int key)
        {
            return articleLikeAccess.CountLikesByArticleId(key);
        }
    }
}
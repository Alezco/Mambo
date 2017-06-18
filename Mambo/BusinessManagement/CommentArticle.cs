using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.BusinessManagement
{
    public class CommentArticle : ICrud<DBO.CommentArticle>
    {
        private DataAccess.CommentArticle commentArticleAccess;
        public CommentArticle()
        {
            commentArticleAccess = new DataAccess.CommentArticle();
        }

        public bool Create(DBO.CommentArticle obj)
        {
            return commentArticleAccess.Create(obj);
        }

        public bool Delete(int key)
        {
            return commentArticleAccess.Delete(key);
        }

        public DBO.CommentArticle Get(int key)
        {
            return commentArticleAccess.Get(key);
        }

        public List<DBO.CommentArticle> GetAll()
        {
            return commentArticleAccess.GetAll();
        }

        public bool Update(DBO.CommentArticle obj)
        {
            return commentArticleAccess.Update(obj);
        }
    }
}
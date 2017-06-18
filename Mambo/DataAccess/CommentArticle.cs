using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.DataAccess
{
    public class CommentArticle : ICrud<DBO.CommentArticle>
    {
        public bool Create(DBO.CommentArticle obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.CreateComment_Article(obj.UserId, obj.ArticleId, obj.CreationDate, obj.CommentContent).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.DeleteComment_Article(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DBO.CommentArticle Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetComment_Article(key).FirstOrDefault();
                    return new DBO.CommentArticle(result.id, result.userID, result.articleID, result.creationDate, result.commentContent);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DBO.CommentArticle> GetAll(Type t)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_COMMENT_ARTICLE> tCommentArticles = bdd.T_COMMENT_ARTICLE.ToList();
                    List<DBO.CommentArticle> commentArticles = new List<DBO.CommentArticle>();
                    foreach (T_COMMENT_ARTICLE tCommentArticle in tCommentArticles)
                    {
                        DBO.CommentArticle commentArticle = new DBO.CommentArticle(tCommentArticle.id, tCommentArticle.userID, tCommentArticle.articleID,
                                                                                tCommentArticle.creationDate, tCommentArticle.commentContent);
                        commentArticles.Add(commentArticle);
                    }
                    return commentArticles;
                }
            }

            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(DBO.CommentArticle obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateComment_Article(obj.Id, obj.UserId, obj.ArticleId, obj.CreationDate, obj.CommentContent).FirstOrDefault();

                    return req != null && obj.isEqual(new DBO.CommentArticle(req.articleID, req.userID, req.articleID, req.creationDate, req.commentContent));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
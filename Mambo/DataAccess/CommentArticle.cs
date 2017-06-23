using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;
using System.Diagnostics;

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
            catch (Exception exception)
            {
                Debug.WriteLine("CommentArticle Exception");
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
                    long result = bdd.DeleteComment_Article(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("CommentArticle Exception");
                Debug.WriteLine(exception.ToString());
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
            catch (Exception exception)
            {
                Debug.WriteLine("CommentArticle Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<DBO.CommentArticle> GetCommentsByArticleId(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_COMMENT_ARTICLE> tListComments = bdd.T_COMMENT_ARTICLE.Where(x => x.articleID == key).ToList();
                    if (tListComments == null)
                        return null;
                    List<DBO.CommentArticle> listComment = new List<DBO.CommentArticle>();
                    foreach (T_COMMENT_ARTICLE tComment in tListComments)
                    {
                        listComment.Add(new DBO.CommentArticle(tComment.id, tComment.userID, tComment.articleID, tComment.creationDate, tComment.commentContent));
                    }
                    return listComment;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("CommentArticle Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<DBO.CommentArticle> GetAll()
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

            catch (Exception exception)
            {
                Debug.WriteLine("CommentArticle Exception");
                Debug.WriteLine(exception.ToString());
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
            catch (Exception exception)
            {
                Debug.WriteLine("CommentArticle Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }

        public int CountCommentsByArticleId(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_COMMENT_ARTICLE> tListComments = bdd.T_COMMENT_ARTICLE.Where(x => x.articleID == key).ToList();
                    return tListComments.Count;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("CommentArticle Exception");
                Debug.WriteLine(exception.ToString());
                return 0;
            }
        }
    }
}
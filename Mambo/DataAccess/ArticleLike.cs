using Mambo.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;
using System.Diagnostics;

namespace Mambo.DataAccess
{
    public class ArticleLike : ICrud<DBO.ArticleLike>
    {
        public bool Create(DBO.ArticleLike obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long result = bdd.CreateArticle_Like(obj.UserId, obj.ArticleId).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ArticleLike Exception");
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
                    long result = bdd.DeleteArticle_Like(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ArticleLike Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }

        public DBO.ArticleLike Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetArticle_Like(key).FirstOrDefault();
                    return new DBO.ArticleLike(result.id, result.userID, result.articleID);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ArticleLike Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<DBO.ArticleLike> GetAll()
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_ARTICLE_LIKE> tArticleLikes = bdd.T_ARTICLE_LIKE.ToList();
                    List<DBO.ArticleLike> articleLikes = new List<DBO.ArticleLike>();
                    foreach (T_ARTICLE_LIKE tArticleLike in tArticleLikes)
                    {
                        DBO.ArticleLike articleLike = new DBO.ArticleLike(tArticleLike.id, tArticleLike.userID, tArticleLike.articleID);
                        articleLikes.Add(articleLike);
                    }
                    return articleLikes;
                }
            }

            catch (Exception exception)
            {
                Debug.WriteLine("ArticleLike Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public bool Update(DBO.ArticleLike obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateArticle_Like(obj.Id, obj.UserId, obj.ArticleId).FirstOrDefault();

                    return req != null && obj.isEqual(new DBO.ArticleLike(req.articleID, req.userID, req.articleID));
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ArticleLike Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }
    }
}
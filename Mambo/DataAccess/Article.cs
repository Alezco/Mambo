using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;

namespace Mambo.DataAccess
{
    public class Article
    {
        public bool Create(DBO.Article obj, DBO.Resources resource)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    long resultArticle = bdd.CreateArticle(obj.AdminId, obj.CreationDate, obj.Status, obj.NbViews).FirstOrDefault().Value;
                    if (resultArticle > 0)
                    {
                        T_ARTICLE tArticle = bdd.T_ARTICLE.ToList().Where(x => x.id == resultArticle).FirstOrDefault();
                        T_RESOURCES tResource = bdd.T_RESOURCES.ToList().Where(x => x.id == resource.Id).FirstOrDefault();

                        tArticle.T_RESOURCES.Add(tResource);
                        return true;
                    }
                    return false;
                    
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
                    long result = bdd.DeleteArticle(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DBO.Article Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetArticle(key).FirstOrDefault();
                    //return new DBO.Article(result.id, result.adminID, result.MONIDDERESOURCES, result.creationDate, result.status, result.nbViews);
                    return new DBO.Article(result.id, result.adminID, result.creationDate, result.status, result.nbViews);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DBO.Article> GetAll()
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_ARTICLE> tArticles = bdd.T_ARTICLE.ToList();
                    List<DBO.Article> articles = new List<DBO.Article>();
                    foreach (T_ARTICLE tArticle in tArticles)
                    {
                        //ADD new DBO.Article(result.id, result.adminID, result.MONIDDERESOURCES, result.creationDate, result.status, result.nbViews);
                        DBO.Article article = new DBO.Article(tArticle.id, tArticle.adminID, tArticle.creationDate, tArticle.status, tArticle.nbViews);
                        articles.Add(article);
                    }
                    return articles;
                }
            }

            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(DBO.Article obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateArticle(obj.Id, obj.AdminId, obj.CreationDate, obj.Status, obj.NbViews).FirstOrDefault();
                    //obj.isEqual(new DBO.Article(result.id, result.adminID, result.MONIDDERESOURCES, result.creationDate, result.status, result.nbViews));
                    return req != null && obj.isEqual(new DBO.Article(req.adminID, req.creationDate, req.status, req.nbViews));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;
using System.Diagnostics;

namespace Mambo.DataAccess
{
    public class Article
    {
        public int Create(DBO.Article obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    int resultArticle = bdd.CreateArticle(obj.AdminId, obj.CreationDate, obj.Status, obj.NbViews).FirstOrDefault().Value;
                    return resultArticle;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Article Exception");
                Debug.WriteLine(exception.ToString());
                return 0;
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
            catch (Exception exception)
            {
                Debug.WriteLine("Article Exception");
                Debug.WriteLine(exception.ToString());
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

                    T_ARTICLE tArticle = bdd.T_ARTICLE.ToList().Where(x => x.id == key).FirstOrDefault();
                    List<T_RESOURCES> tResources = tArticle.T_RESOURCES.ToList();

                    DBO.Article article = new DBO.Article(result.id, result.adminID, result.creationDate, result.status, result.nbViews);
                    List<DBO.Resources> resourcesList = new List<DBO.Resources>();
                    foreach (T_RESOURCES item in tResources)
                    {
                        DBO.Resources r = new DBO.Resources(item.id, item.languageID, item.title, item.description, item.path);
                        resourcesList.Add(r);
                    }
                    article.ResourcesList = resourcesList;
                    return article;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Article Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<DBO.Article> GetArticlesNotValidated()
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_ARTICLE> tListArticles = bdd.T_ARTICLE.Where(x => x.status != "VALIDATED").ToList(); 
                    if (tListArticles == null)
                        return null;
                    List<DBO.Article> listArticle = new List<DBO.Article>();
                    foreach (T_ARTICLE tArticle in tListArticles)
                    {
                        List<T_RESOURCES> tListResources = tArticle.T_RESOURCES.ToList();
                        List<DBO.Resources> resourcesList = new List<DBO.Resources>();
                        foreach (T_RESOURCES item in tListResources)
                        {
                            DBO.Resources resources = new DBO.Resources(item.id, item.languageID, item.title, item.description, item.path);
                            resourcesList.Add(resources);
                        }
                        listArticle.Add(new DBO.Article(tArticle.id, tArticle.adminID, resourcesList, tArticle.creationDate, tArticle.status, tArticle.nbViews));
                    }
                    return listArticle;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Article Exception");
                Debug.WriteLine(exception.ToString());
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
                        List<T_RESOURCES> tResourcesList = tArticle.T_RESOURCES.ToList();
                        List<DBO.Resources> resourcesList = new List<DBO.Resources>();
                        foreach (T_RESOURCES item in tResourcesList)
                        {
                            DBO.Resources resources = new DBO.Resources(item.id, item.languageID, item.title, item.description, item.path);
                            resourcesList.Add(resources);
                        }
                        
                        //ADD new DBO.Article(result.id, result.adminID, result.MONIDDERESOURCES, result.creationDate, result.status, result.nbViews);
                        DBO.Article article = new DBO.Article(tArticle.id, tArticle.adminID, resourcesList, tArticle.creationDate, tArticle.status, tArticle.nbViews);
                        articles.Add(article);
                    }
                    return articles;
                }
            }

            catch (Exception exception)
            {
                Debug.WriteLine("Article Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public bool Update(DBO.Article obj, DBO.Resources resources)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateArticle(obj.Id, obj.AdminId, obj.CreationDate, obj.Status, obj.NbViews).FirstOrDefault();

                    T_ARTICLE tArticle = bdd.T_ARTICLE.ToList().Where(x => x.id == obj.Id).FirstOrDefault();
                    T_RESOURCES tResource = bdd.T_RESOURCES.ToList().Where(x => x.id == resources.Id).FirstOrDefault();

                    bdd.T_ARTICLE.Attach(tArticle);
                    bdd.T_RESOURCES.Attach(tResource);

                    tArticle.T_RESOURCES.Add(tResource);
                    tResource.T_ARTICLE.Add(tArticle);
                    bdd.SaveChanges();

                    //obj.isEqual(new DBO.Article(result.id, result.adminID, result.MONIDDERESOURCES, result.creationDate, result.status, result.nbViews));
                    return req != null && obj.isEqual(new DBO.Article(req.adminID, req.creationDate, req.status, req.nbViews));
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Article Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }

        public bool Update(DBO.Article obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateArticle(obj.Id, obj.AdminId, obj.CreationDate, obj.Status, obj.NbViews).FirstOrDefault();
                    return obj.isEqual(new DBO.Article(req.adminID, req.creationDate, req.status, req.nbViews));
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Article Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }
    }
}
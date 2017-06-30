using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mambo.DBO;
using System.Diagnostics;

namespace Mambo.DataAccess
{
    public class Resources
    {
        public int Create(DBO.Resources obj)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    int resultResources = bdd.CreateResources(obj.Title, obj.Description, obj.Path, obj.LanguageId).FirstOrDefault().Value;
                    return resultResources;

                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Resource Exception");
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
                    long result = bdd.DeleteResources(key).FirstOrDefault().Value;
                    return result > 0;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Language Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }

        public bool DeleteResourceLink(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    T_RESOURCES tResource = bdd.T_RESOURCES.Where(x => x.id == key).FirstOrDefault();
                    T_ARTICLE tArticle = tResource.T_ARTICLE.FirstOrDefault();
                    tArticle.T_RESOURCES.Remove(tResource);
                    tResource.T_ARTICLE.Remove(tArticle);
                    bdd.SaveChanges();
                }
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Language Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
         
        }

        public DBO.Resources Get(int key)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var result = bdd.GetResources(key).FirstOrDefault();
                    //return new DBO.Resources(result.id, result.languageID, MALISTED'ARTICLE, result.title, result.description, result.path);

                    T_RESOURCES tResource = bdd.T_RESOURCES.ToList().Where(x => x.id == key).FirstOrDefault();
                    List<T_ARTICLE> tArticles = tResource.T_ARTICLE.ToList();
                    DBO.Resources resources = new DBO.Resources(result.id, result.languageID, result.title, result.description, result.path);
                    List<DBO.Article> articles = new List<DBO.Article>();
                    foreach (T_ARTICLE item in tArticles)
                    {
                        DBO.Article a = new DBO.Article(item.id, item.adminID, item.creationDate, item.status, item.nbViews);
                        articles.Add(a);
                    }
                    resources.ArticlesList = articles;
                    return resources;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Language Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<DBO.Resources> GetAll()
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    List<T_RESOURCES> tResources = bdd.T_RESOURCES.ToList();
                    List<DBO.Resources> resources = new List<DBO.Resources>();
                    foreach (T_RESOURCES tResource in tResources)
                    {

                        List<T_ARTICLE> tArticleList = tResource.T_ARTICLE.ToList();
                        List<DBO.Article> articleList = new List<DBO.Article>();
                        foreach (T_ARTICLE item in tArticleList)
                        {
                            DBO.Article article = new DBO.Article(item.id, item.adminID, item.creationDate, item.status, item.nbViews);
                            articleList.Add(article);
                        }

                        //ADD new DBO.Article(tResources.id, tResources.adminID, tResources.MALISTED'ARTICLE, tResources.creationDate, tResources.status, tResources.nbViews);
                        DBO.Resources resource = new DBO.Resources(tResource.id, tResource.languageID, articleList, tResource.title, tResource.description, tResource.path);
                        resources.Add(resource);
                    }
                    return resources;
                }
            }

            catch (Exception exception)
            {
                Debug.WriteLine("Language Exception");
                Debug.WriteLine(exception.ToString());
                return null;
            }
        }

        public bool Update(DBO.Resources obj, DBO.Article article)
        {
            try
            {
                using (dbNetEntities bdd = new dbNetEntities())
                {
                    var req = bdd.UpdateResources(obj.Id, obj.Title, obj.Description, obj.Path, obj.LanguageId).FirstOrDefault();

                    T_RESOURCES tResource = bdd.T_RESOURCES.ToList().Where(x => x.id == obj.Id).FirstOrDefault();
                    T_ARTICLE tArticle = bdd.T_ARTICLE.ToList().Where(x => x.id == article.Id).FirstOrDefault();

                    bdd.T_ARTICLE.Attach(tArticle);
                    bdd.T_RESOURCES.Attach(tResource);

                    tArticle.T_RESOURCES.Add(tResource);
                    tResource.T_ARTICLE.Add(tArticle);
                    bdd.SaveChanges();

                    //obj.isEqual(new DBO.Article(result.id, result.adminID, result.MONIDDERESOURCES, result.creationDate, result.status, result.nbViews));
                    return req != null && obj.isEqual(new DBO.Resources(req.languageID, req.title, req.description, req.path));
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Language Exception");
                Debug.WriteLine(exception.ToString());
                return false;
            }
        }
    }
}
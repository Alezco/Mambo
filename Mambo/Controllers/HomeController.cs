using Mambo.DataAccess;
using Mambo.DBO;
using Mambo.LanguageManagement;
using Mambo.Models;
using Mambo.RSS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mambo.Controllers
{
    [Localization("en")]
    public class HomeController : Controller
    {
        private dbNetEntities db = new dbNetEntities();

        private BusinessManagement.Article articleManagement = new BusinessManagement.Article();
        private BusinessManagement.Translation translationManagement = new BusinessManagement.Translation();
        private BusinessManagement.CommentArticle commentManagement = new BusinessManagement.CommentArticle();
        private BusinessManagement.ArticleLike likeManagement = new BusinessManagement.ArticleLike();
        private BusinessManagement.User userManagement = new BusinessManagement.User();

        public ActionResult Index(string searchString)
        {      
            List<DBO.Article> articles = articleManagement.GetArticlesValidated();
            List<DBO.Translation> translations = translationManagement.GetAll();

            ArticleViewModel myModel = new ArticleViewModel()
            {
                Articles = articles,
                Translations = translations
            };

            if (!String.IsNullOrEmpty(searchString))
            {
                List<DBO.Translation> translationList = new List<DBO.Translation>();
                foreach (var item in translations)
                {
                    if (item.TranslationArticleTitle.Contains(searchString) || item.TranslationArticleContent.Contains(searchString))
                    {
                        translationList.Add(item);
                        continue;
                    }
                    DBO.Article article = articleManagement.Get(item.ArticleId);
                    List<DBO.Resources> resourceList = article.ResourcesList;
                    foreach (var resource in resourceList)
                    {
                        if (resource.Title.Contains(searchString) || resource.Description.Contains(searchString))
                        {
                            translationList.Add(item);
                        }
                    }
                }

                myModel = new ArticleViewModel()
                {
                    Articles = articles,
                    Translations = translationList
                };
            }
            
            return View(myModel);
        }
        
        public ActionResult ArticleDetails(ArticleDetailModel model, int? id)
        {
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            if (model.UserComment != null)
            {
                AddComment(model);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Article à afficher
            DBO.Article article = articleManagement.Get(id.Value);

            // Traduction liées à l'article
            List<DBO.Translation> translations = translationManagement.GetTranslationsByArticleId(id.Value);

            // Liste des commentaires liés à l'article
            List<CommentModel> commentModelList = new List<CommentModel>();
            List<DBO.CommentArticle> comments = commentManagement.GetCommentsByArticleId(id.Value);

            foreach (DBO.CommentArticle comment in comments)
            {
                CommentModel commentModel = new CommentModel()
                {
                    Comment = comment.CommentContent,
                    Username = userManagement.Get(comment.UserId).Pseudo,
                    Date = comment.CreationDate
                };
                commentModelList.Add(commentModel);
            }
            int views = article.NbViews;


            ArticleDetailModel myModel = new ArticleDetailModel()
            {
                Article = article,
                Translations = translations,
                Comments = commentModelList,
                NbLikes = -1,
                IsFavorite = false,
                NbViews = views
            };

            // Nombre de likes lié à l'article
            DBO.User currentUser = userManagement.GetByEmail(HttpContext.User.Identity.Name);
            if (currentUser != null)
            {
                int likes = likeManagement.CountLikesByArticleId(id.Value);
                List<DBO.ArticleLike> lal = likeManagement.GetAll();

                bool isLikedByCurrentUser = false;
                foreach (var elt in lal)
                {
                    if (elt.UserId == currentUser.Id && elt.ArticleId == id.Value)
                    {
                        isLikedByCurrentUser = true;
                        break;
                    }
                }

                myModel = new ArticleDetailModel()
                {
                    Article = article,
                    Translations = translations,
                    Comments = commentModelList,
                    NbLikes = likes,
                    IsFavorite = isLikedByCurrentUser,
                    NbViews = views
                };
            }

            if (myModel == null)
            {
                return HttpNotFound();
            }

            article.NbViews += 1;
            articleManagement.Update(article);
            return View(myModel);
        }

        private void AddComment(ArticleDetailModel model)
        {
            string t = model.UserComment.Text;
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.UserComment.Text))
                {
                    ModelState.AddModelError("", "Le champ ne peut pas être vide");
                }
                DBO.User currentUser = userManagement.GetByEmail(HttpContext.User.Identity.Name);
                commentManagement.Create(new DBO.CommentArticle(currentUser.Id, model.Article.Id, DateTime.Now, model.UserComment.Text));
                ModelState.Clear();
                DBO.Article tmp = articleManagement.Get(model.Article.Id);
                tmp.NbViews -= 1;
                articleManagement.Update(tmp);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        } 

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Rss()
        {
            List<DBO.Translation> listTransaction = translationManagement.GetAll();
            List<DBO.Translation> listArticlesInWaiting = new List<DBO.Translation>();
            foreach (var elt in listTransaction)
            {
                DBO.Article a = articleManagement.Get(elt.ArticleId);
                if (a.Status == "WAITING_VALIDATION")
                {
                    listArticlesInWaiting.Add(elt);
                }
            }
            var feed = new SyndicationFeed("Articles waiting for translation", "Mambo RSS Feed",
                new Uri("https://raw.githubusercontent.com/Alezco/Mambo/master/Ressources/file_placeholder.png"),
                Guid.NewGuid().ToString(), DateTime.Now);
            var items = new List<SyndicationItem>();
            foreach (DBO.Translation a in listTransaction)
            {
                DBO.Article elt = articleManagement.Get(a.ArticleId);
                Uri tempValue = new Uri("https://fr.wikipedia.org/wiki/Mambo");
                if (elt.ResourcesList.Count > 0 && Uri.TryCreate(elt.ResourcesList[0].Path, UriKind.RelativeOrAbsolute, out tempValue))
                {
                }
                var item =
                    new SyndicationItem(a.TranslationArticleTitle, a.TranslationArticleContent, tempValue);
                items.Add(item);
            }
            feed.Items = items;
            return new RSSActionResult { Feed = feed };
        }

        public ActionResult LikeAction(int modelID)
        {
            DBO.User currentUser = userManagement.GetByEmail(HttpContext.User.Identity.Name);
            if (ModelState.IsValid && currentUser != null)
            {
                DBO.ArticleLike al = new DBO.ArticleLike(currentUser.Id, modelID);
                List<DBO.ArticleLike> als = likeManagement.GetAll();
                int isLikedByCurrentUser = -1;
                foreach (var elt in als)
                {
                    if (elt.UserId == currentUser.Id && elt.ArticleId == modelID)
                    {
                        isLikedByCurrentUser = elt.Id;
                        break;
                    }
                }
                if (isLikedByCurrentUser < 0)
                    likeManagement.Create(al);
                else
                    likeManagement.Delete(isLikedByCurrentUser);
            }
            DBO.Article tmp = articleManagement.Get(modelID);
            tmp.NbViews -= 1;
            articleManagement.Update(tmp);
            return RedirectToAction("ArticleDetails", new { id = modelID });
        }
    }
}
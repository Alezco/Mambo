using Mambo.DataAccess;
using Mambo.DBO;
using Mambo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mambo.Controllers
{
    public class HomeController : Controller
    {
        private dbNetEntities db = new dbNetEntities();

        public ActionResult Index()
        {
            BusinessManagement.Article articleManagement = new BusinessManagement.Article();
            List<DBO.Article> articles = articleManagement.GetAll();
            BusinessManagement.Translation translationManagement = new BusinessManagement.Translation();
            List<DBO.Translation> translations = translationManagement.GetAll();

            ArticleViewModel myModel = new ArticleViewModel()
            {
                Articles = articles,
                Translations = translations
            };

            return View(myModel);
        }

        public ActionResult ArticleDetails(ArticleDetailModel model, int? id)
        {
            if (model.UserComment != null)
            {
                AddComment(model);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Article à afficher
            BusinessManagement.Article articleManagement = new BusinessManagement.Article();
            DBO.Article article = articleManagement.Get(id.Value);

            // Traduction liées à l'article
            BusinessManagement.Translation translationManagement = new BusinessManagement.Translation();
            List<DBO.Translation> translations = translationManagement.GetTranslationsByArticleId(id.Value);

            // Liste des commentaires liés à l'article
            BusinessManagement.CommentArticle commentManagement = new BusinessManagement.CommentArticle();
            BusinessManagement.User userManagement = new BusinessManagement.User();
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

            // Nombre de likes lié à l'article
            BusinessManagement.ArticleLike likeManagement = new BusinessManagement.ArticleLike();
            int likes = likeManagement.CountLikesByArticleId(id.Value);

            ArticleDetailModel myModel = new ArticleDetailModel()
            {
                Article = article,
                Translations = translations,
                Comments = commentModelList,
                NbLikes = likes
            };

            if (myModel == null)
            {
                return HttpNotFound();
            }
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
                BusinessManagement.User userManagement = new BusinessManagement.User();
                DBO.User currentUser = userManagement.GetByEmail(HttpContext.User.Identity.Name);
                BusinessManagement.CommentArticle commentManagement = new BusinessManagement.CommentArticle();
                commentManagement.Create(new DBO.CommentArticle(currentUser.Id, model.Article.Id, DateTime.Now, model.UserComment.Text));
                ModelState.Clear();
            }
        }

        [Authorize(Roles = "ADMIN")]
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
    }
}
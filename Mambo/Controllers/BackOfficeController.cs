using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mambo.DBO;
using Mambo.DataAccess;
using Mambo.Models;

namespace Mambo.Controllers
{
    public class BackOfficeController : Controller
    {
        private dbNetEntities db = new dbNetEntities();

        // GET: BackOffice
        [Authorize(Roles = "ADMIN, TRADUCTEUR")]
        public ActionResult Index()
        {
            BusinessManagement.Article articleManagement = new BusinessManagement.Article();
            return View(articleManagement.GetArticlesNotValidated());
        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult Statistics()
        {
            BusinessManagement.Article articleManagement = new BusinessManagement.Article();
            BusinessManagement.Translation translationManagement = new BusinessManagement.Translation();
            BusinessManagement.CommentArticle commentManagement = new BusinessManagement.CommentArticle();
            BusinessManagement.ArticleLike articleLikeManagment = new BusinessManagement.ArticleLike();

            StatisticModel statModel = new StatisticModel();
            List<DBO.Article> articles = articleManagement.GetArticlesValidated();

            foreach (DBO.Article article in articles)
            {
                List<DBO.Translation> translations = translationManagement.GetTranslationsByArticleId(article.Id);
                int nbComments = commentManagement.CountCommentsByArticleId(article.Id);
                int nbLikes = articleLikeManagment.CountLikesByArticleId(article.Id);
                ArticleStatisticModel articleStatModel = new ArticleStatisticModel()
                {
                    Article = article,
                    Translations = translations,
                    NbComments = nbComments,
                    NbLikes = nbLikes
                };
                statModel.ArticleList.Add(articleStatModel);
            }

            return View(statModel);
        }
        
        // GET: BackOffice/Details/5
        [Authorize(Roles = "ADMIN, TRADUCTEUR")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBO.Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: BackOffice/Create
        [Authorize(Roles = "ADMIN, TRADUCTEUR")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ArticleCreationModel newArticle)
        {
            if (ModelState.IsValid)
            {
                // Création de l'article
                BusinessManagement.User userManagement = new BusinessManagement.User();
                BusinessManagement.Article articleManagement = new BusinessManagement.Article();
                DBO.User currentUser = userManagement.GetByEmail(HttpContext.User.Identity.Name);
                DBO.Article article = new DBO.Article(currentUser.Id, DateTime.Now, "WAITING_TRANSLATION", 0);
                int articleId = articleManagement.Create(article);

                // Création de la traduction
                int languageId = (int) newArticle.Language;
                BusinessManagement.Language languageManagement = new BusinessManagement.Language();
                BusinessManagement.Translation translationManagmeent = new BusinessManagement.Translation();
                DBO.Translation translation = new DBO.Translation(articleId, currentUser.Id, languageId, newArticle.Title, newArticle.Text);
                translationManagmeent.Create(translation);

                // Création de la liste de ressources

                return RedirectToAction("Index");
            }
            return View(newArticle);
        }

        // GET: BackOffice/Edit/5
        [Authorize(Roles = "ADMIN, TRADUCTEUR")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessManagement.Article articleManagement = new BusinessManagement.Article();
            DBO.Article article = articleManagement.Get(id.Value);

            BusinessManagement.Resources resourceManagement = new BusinessManagement.Resources();
            List<DBO.Resources> resources = resourceManagement.GetAll();
            List<SelectListItem> items = new List<SelectListItem>();

            for(int i = 0; i < resources.Count; i++)
            {
                items.Add(new SelectListItem { Text = resources.ElementAt(i).Title, Value = i.ToString() });
            }
            ViewBag.ResourcesList = items;
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: BackOffice/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdminId,CreationDate,Status,NbViews")] DBO.Article article)
        {
            if (ModelState.IsValid)
            {
                BusinessManagement.Article articleManagement = new BusinessManagement.Article();
                articleManagement.Update(article);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: BackOffice/Delete/5
        [Authorize(Roles = "ADMIN, TRADUCTEUR")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBO.Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: BackOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBO.Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

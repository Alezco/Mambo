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
using System.Diagnostics;

namespace Mambo.Controllers
{
    public class BackOfficeController : Controller
    {
        private dbNetEntities db = new dbNetEntities();

        private BusinessManagement.Article articleManagement = new BusinessManagement.Article();
        private BusinessManagement.Translation translationManagement = new BusinessManagement.Translation();
        private BusinessManagement.CommentArticle commentManagement = new BusinessManagement.CommentArticle();
        private BusinessManagement.ArticleLike articleLikeManagment = new BusinessManagement.ArticleLike();
        private BusinessManagement.User userManagement = new BusinessManagement.User();
        private BusinessManagement.Language languageManagement = new BusinessManagement.Language();
        private BusinessManagement.Resources resourceManagement = new BusinessManagement.Resources();

        private ArticleCreationModel articleModel;

        // GET: BackOffice
        [Authorize(Roles = "ADMIN, TRADUCTEUR")]
        public ActionResult Index()
        {
            return View(articleManagement.GetArticlesNotValidated());
        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult Statistics(string sortOrder)
        {
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

            switch (sortOrder)
            {
                case "sortComment":
                    statModel.ArticleList = statModel.ArticleList.OrderByDescending(x => x.NbComments).ToList();
                    break;
                case "sortLike":
                    statModel.ArticleList = statModel.ArticleList.OrderByDescending(x => x.NbLikes).ToList();
                    break;
                case "sortView":
                    statModel.ArticleList = statModel.ArticleList.OrderByDescending(x => x.Article.NbViews).ToList();
                    break;
                case "sortDate":
                    statModel.ArticleList = statModel.ArticleList.OrderByDescending(x => x.Article.CreationDate).ToList();
                    break;
                default:
                    statModel.ArticleList = statModel.ArticleList.OrderBy(x => x.Article.Id).ToList();
                    break;
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
            DBO.Article article = articleManagement.Get(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            List<DBO.Translation> translations = translationManagement.GetTranslationsByArticleId(id.Value);
            ArticleDetailModel articleModel = new ArticleDetailModel()
            {
                Article = article,
                Translations = translations
            };

            return View(articleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidateArticle(int? id)
        {
            DBO.Article article = articleManagement.Get(id.Value);
            if (article.Status.Equals("WAITING_VALIDATION"))
                article.Status = "VALIDATED";
            articleManagement.Update(article);
            return RedirectToAction("Index");
        }

        // GET: BackOffice/Create
        [Authorize(Roles = "ADMIN")]
        public ActionResult Create()
        {
            articleModel = new ArticleCreationModel();
            return View(articleModel);
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
                DBO.User currentUser = userManagement.GetByEmail(HttpContext.User.Identity.Name);
                DBO.Article article = new DBO.Article(currentUser.Id, DateTime.Now, "WAITING_TRANSLATION", 0)
                {
                    ResourcesList = SessionBag.Current.Resources
                };

                int articleId = articleManagement.Create(article);
                DBO.Article updateArticle = articleManagement.Get(articleId);

                // Création de la traduction
                int languageId = (int)newArticle.Language;
                DBO.Translation translation = new DBO.Translation(articleId, currentUser.Id, languageId, newArticle.Title, newArticle.Text);
                translationManagement.Create(translation);

                foreach (DBO.Resources resource in SessionBag.Current.Resources)
                {
                    resource.LanguageId = languageId;
                    int resourceId = resourceManagement.Create(resource);
                    DBO.Resources updateResource = resourceManagement.Get(resourceId);
                    articleManagement.Update(updateArticle, updateResource);
                }
                SessionBag.Current.Resources = null;

                // Création de la liste de ressources
                return RedirectToAction("Index");
            }
            return View(newArticle);
        }

        public ActionResult CreateResource(Models.ResourceCreationModel newResource)
        {
            if (ModelState.IsValid)
            {
                List<DBO.Resources> listResources = SessionBag.Current.Resources;
                if (listResources == null)
                {
                    listResources = new List<DBO.Resources>();
                }
                DBO.Resources resource = new DBO.Resources(newResource.MediaName, newResource.MediaDescription, newResource.MediaPath);
                listResources.Add(resource);
                SessionBag.Current.Resources = listResources;
                //ModelState.Clear();
                return View("Create");
            }
            return View("Create"); 
        }

        // GET: BackOffice/Edit/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBO.Article article = articleManagement.Get(id.Value);
            List<DBO.Resources> resources = resourceManagement.GetAll();
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < resources.Count; i++)
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
                articleManagement.Update(article);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: BackOffice/Translate/5
        [Authorize(Roles = "TRADUCTEUR")]
        public ActionResult Translate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DBO.Article article = articleManagement.Get(id.Value);
            List<DBO.Translation> translations = translationManagement.GetTranslationsByArticleId(id.Value);

            List<DBO.Language> languages = new List<DBO.Language>();
            foreach (var item in translations)
            {
                DBO.Language language = languageManagement.Get(item.LanguageId);
                language.Id = item.LanguageId;
                languages.Add(language);
            }

            List<DBO.Language> allLanguages = languageManagement.GetAll();
            foreach (var item in languages)
            {
                DBO.Language alreadyTranslated = allLanguages.Where(x => x.LanguageName == item.LanguageName).FirstOrDefault();
                allLanguages.Remove(alreadyTranslated);
            }

            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < allLanguages.Count; i++)
            {
                items.Add(new SelectListItem { Text = allLanguages.ElementAt(i).LanguageName, Value = allLanguages.ElementAt(i).Id.ToString() });
            }

            Models.ArticleTranslateModel articleTranslateModel = new Models.ArticleTranslateModel()
            {
                Article = article,
                Translations = translations,
                ExistingTranslatedLanguage = languages,
                LanguageSelectList = items
            };


            if (article == null)
            {
                return HttpNotFound();
            }
            return View(articleTranslateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Translate(Models.ArticleTranslateModel translateModel, string titleTranslatedString, string contentTranslatedString)
        {
            List<DBO.Language> allLanguages = languageManagement.GetAll();
            List<DBO.Translation> translations = translationManagement.GetTranslationsByArticleId(translateModel.Article.Id);
            List<DBO.Language> languages = new List<DBO.Language>();
            foreach (var item in translations)
            {
                DBO.Language language = languageManagement.Get(item.LanguageId);
                languages.Add(language);
            }
            
            foreach (var item in languages)
            {
                allLanguages.Remove(item);
            }
            
            List<SelectListItem> items = new List<SelectListItem>();
            if (ModelState.IsValid)
            {
                int selectedLanguage = int.Parse(translateModel.SelectedLanguage);
                if (titleTranslatedString != null && contentTranslatedString != null)
                {
                    if (titleTranslatedString.Trim() != "" && contentTranslatedString.Trim() != "")
                    {
                        DBO.Language curLang = allLanguages.Where(x => x.Id == selectedLanguage).FirstOrDefault();
                        DBO.Translation curTranslate = translations.Where(x => x.LanguageId == curLang.Id).FirstOrDefault();
                        
                        string str = User.Identity.Name;
                        DBO.User curUser = userManagement.GetByEmail(str);
                        
                        if (curTranslate != null)
                        {
                            curTranslate.TranslationArticleContent = contentTranslatedString;
                            curTranslate.TranslationArticleTitle = titleTranslatedString;
                            curTranslate.TranslatorId = curUser.Id;
                            translationManagement.Update(curTranslate);
                        }
                        else
                        {
                            curTranslate = new DBO.Translation();
                            curTranslate.LanguageId = curLang.Id;
                            curTranslate.ArticleId = translateModel.Article.Id;
                            curTranslate.TranslationArticleContent = contentTranslatedString;
                            curTranslate.TranslationArticleTitle = titleTranslatedString;
                            curTranslate.TranslatorId = curUser.Id;
                            translationManagement.Create(curTranslate);
                        }
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(translateModel);
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

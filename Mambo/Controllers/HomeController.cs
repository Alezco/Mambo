using Mambo.DataAccess;
using Mambo.DBO;
using Mambo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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
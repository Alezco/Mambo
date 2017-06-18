using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mambo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*BusinessManagement.User userBusiness = new BusinessManagement.User();
            BusinessManagement.Role roleBusiness = new BusinessManagement.Role();
            BusinessManagement.Translation translationBusiness = new BusinessManagement.Translation();
            BusinessManagement.Article articleBusiness = new BusinessManagement.Article();
            BusinessManagement.Language language = new BusinessManagement.Language();
            BusinessManagement.Resources resourcesBusiness = new BusinessManagement.Resources();

            //roleBusiness.Create(new DBO.Role("Admin"));
            //userBusiness.Create(new DBO.User(1, "admin", "admin@test.fr", "admin"));


            DBO.Article article = new DBO.Article(1, DateTime.Now, "test", 1);
            DBO.Resources resource = new DBO.Resources(1, "test ressource", "super description", "un path");
            articleBusiness.Create(article);
            //language.Create(new DBO.Language("français"));
            resourcesBusiness.Create(resource);
            article.Id = 2;
            resource.Id = 2;
            articleBusiness.Update(article, resource);*/


            return View();
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
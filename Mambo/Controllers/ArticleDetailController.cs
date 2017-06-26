using Mambo.LanguageManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mambo.Controllers
{
    [Localization("en")]
    public class ArticleDetailController : Controller
    {
        // GET: ArticleDetail
        public ActionResult Index()
        {
            return View();
        }
    }
}
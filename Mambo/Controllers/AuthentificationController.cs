using Mambo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mambo.Controllers
{
    public class AuthentificationController : Controller
    {
        // GET: Authentification
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Login model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, BusinessManagement.Security.GenerateHash(model.Password)))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.Email, model.RememberMe);
                }

                ModelState.AddModelError("", "Incorrect username and/or password");
            }
            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }

        public ActionResult Register(Register model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.PasswordConfirm))
                {
                    ModelState.AddModelError("", "Incorrect username and/or password");
                    return View(model);
                }
                if (model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError("", "Password Mismatch");
                    return View(model);
                }
                BusinessManagement.User bUser = new BusinessManagement.User();
                DBO.User u = new DBO.User(1, model.UserName, model.Email, BusinessManagement.Security.GenerateHash(model.Password));
                var success = bUser.Create(u);
                if (success)
                {
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult Deconnect()
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Clear();
            return View();
        }
    }
}
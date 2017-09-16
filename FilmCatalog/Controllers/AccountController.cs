using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using FilmCatalog.DAL.Models;
using FilmCatalog.DAL.Models.Information;
using FilmCatalog.DAL.Models.ViewModels;

namespace FilmCatalog.Controllers
{

    public class AccountController : Controller
    {
        UnitOfWork unit = new UnitOfWork();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Denied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;

                user = unit.Users.GetAll()
                    .Where(u => u.Email == model.Email && u.Password == model.Password)
                    .FirstOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
    }
}
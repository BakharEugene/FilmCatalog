using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmCatalog.DAL.EF;
using FilmCatalog.DAL.Models;
using FilmCatalog.DAL.Models.Information;
using FilmCatalog.DAL.Models.ViewModels;

namespace FilmCatalog.Controllers
{
    public class FilmsController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var tempItems = db.Films.GetAll();
            var pager = new Pager(tempItems.Count(), page);

            var viewModel = new IndexFilmsViewModel()
            {
                Items = tempItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.GetById(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.GetById(id);

            if (film == null)
            {
                return HttpNotFound();
            }
            if (film.IdUser == db.Users.GetAll().FirstOrDefault(x => x.Email == User.Identity.Name).Id)
            {
                return View(film);
            }
            else
            {
                return RedirectToAction("Denied", "Account");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ReleaseDate,Producer,IdUser,IdPoster")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Update(film);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(film);
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

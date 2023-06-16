using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using app.Models;

namespace app.Controllers
{
    public class FilmController : Controller
    {
        private FilmoviDbContext db = new FilmoviDbContext();

        // GET: Film
        public ActionResult Index()
        {
            var filmovi = db.Filmovi.Include(f => f.Drzava).Include(f => f.Glumci).Include(f => f.Zanr);
            return View(filmovi.ToList());
        }

        // GET: Film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            ViewBag.DrzavaId = new SelectList(db.Drzave, "Id", "Naziv");
            ViewBag.GlumciId = new SelectList(db.Glumci, "Id", "Ime");
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "Id", "Naziv");
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Trajanje,Cijena,ZanrId,DrzavaId,GlumciId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Filmovi.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DrzavaId = new SelectList(db.Drzave, "Id", "Naziv", film.DrzavaId);
            ViewBag.GlumciId = new SelectList(db.Glumci, "Id", "Ime", film.GlumciId);
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "Id", "Naziv", film.ZanrId);
            return View(film);
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrzavaId = new SelectList(db.Drzave, "Id", "Naziv", film.DrzavaId);
            ViewBag.GlumciId = new SelectList(db.Glumci, "Id", "Ime", film.GlumciId);
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "Id", "Naziv", film.ZanrId);
            return View(film);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Trajanje,Cijena,ZanrId,DrzavaId,GlumciId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DrzavaId = new SelectList(db.Drzave, "Id", "Naziv", film.DrzavaId);
            ViewBag.GlumciId = new SelectList(db.Glumci, "Id", "Ime", film.GlumciId);
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "Id", "Naziv", film.ZanrId);
            return View(film);
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Filmovi.Find(id);
            db.Filmovi.Remove(film);
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

        public ActionResult FilmoviPoZanru(int zanrId)
        {

            //using (var dbContext = new FilmoviDbContext())
            //{
            //    List<Film> films = dbContext.Filmovi
            //        .Include("Zanr")
            //        .Where(m => m.ZanrId == ZanrId)
            //        .ToList();

            //    return View("FilmoviPoZanru", films)
            //}

            var filmovi = db.Filmovi.Include("Zanr").Where(m => m.ZanrId == zanrId).ToList();
            return View("FilmoviPoZanru", filmovi);

        }
    }
}

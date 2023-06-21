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
    public class KorisnikController : Controller
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


    }
}

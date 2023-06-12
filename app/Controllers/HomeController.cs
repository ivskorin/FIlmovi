using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using app.Models;
using System.Collections;



namespace app.Controllers
{
    public class HomeController : Controller
    {
        private FilmoviDbContext dbContext;

        public HomeController()
        {
            dbContext = new FilmoviDbContext();
        }
        public ActionResult Index()
        {
            var filmovi = dbContext.Filmovi.Include("Zanr").Include("Drzava").ToList();
            return View(filmovi);
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

            var filmovi = dbContext.Filmovi.Include("Zanr").Where(m => m.ZanrId == zanrId).ToList();
            return View("FilmoviPoZanru",filmovi);
            
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using app.Models;

namespace app.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(app.Models.Korisnik korisnik )
        {
            using (FilmoviDbContext db = new FilmoviDbContext()) { 
                var userDetails = db.Korisnici.Where(x => x.Username == korisnik.Username && x.Password == korisnik.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    korisnik.LoginErrorMessage = "Krivi username ili šifra.";
                    return View("Index", korisnik);
                }
                else if(userDetails.RolaId == 1)
                {
                    Session["Id"] = korisnik.Id;
                    return RedirectToAction("Index", "Film");
                }

                else {
                    Session["Id"] = korisnik.Id;
                    return RedirectToAction("Index", "Korisnik");
                }

            }

            return View("Index", "Film");
        }
        
    }
}
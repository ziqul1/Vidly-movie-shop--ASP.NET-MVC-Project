using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyBest.Models;
using VidlyBest.ViewModels;

namespace VidlyBest.Controllers
{
    public class MoviesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ViewResult Index()
        {
            var movies = db.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
     
    }
}
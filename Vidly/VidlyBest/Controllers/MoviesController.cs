using System;
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

		public ViewResult Create()
		{
			var genres = db.Genres.ToList();

			var viewModel = new MovieFormViewModel
			{
				Genres = genres
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = db.Genres.ToList()
				};

				return View("MovieForm", viewModel);
			}


			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				db.Movies.Add(movie);
			}
			else
			{
				var movieInDb = db.Movies.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}

			db.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}

		public ActionResult Edit(int id)
		{
			var movie = db.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = db.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

	}
}
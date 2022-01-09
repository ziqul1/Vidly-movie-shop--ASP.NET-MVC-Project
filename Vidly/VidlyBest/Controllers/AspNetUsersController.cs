using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyBest.Models;
using VidlyBest.ViewModels;

namespace VidlyBest.Controllers
{
	[Authorize]
	public class AspNetUsersController : Controller
	{
		private MyDbContext db = new MyDbContext();

		// GET: AspNetUsers
		public ActionResult Index()
		{
			if (User.IsInRole(RoleName.CanManageMovies))
			{
				var users = db.AspNetUsers.ToList();
				return View("Index", users);
			}

			return RedirectToAction("Index", "Info");
		}

		public ActionResult Search(string searching)
		{
			var users = db.AspNetUsers.ToList().Where(u => u.Email.Contains(searching) || searching == null).ToList();

			return View("Index", users);
		}

		public ActionResult Edit(string id)
		{
			var user = db.AspNetUsers.SingleOrDefault(u => u.Id == id);

			if (user == null)
				return HttpNotFound();

			var viewModel = new AspNetUserFormViewModel
			{
				AspNetUser = user
			};

			return View("AspNetUserForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(AspNetUser aspNetUser)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new AspNetUserFormViewModel
				{
					AspNetUser = aspNetUser,
				};

				return View("AspNetUserForm", viewModel);
			}

			if (aspNetUser.Id != "")
			{
				var userInDb = db.AspNetUsers.Single(u => u.Id == aspNetUser.Id);

				userInDb.Name = aspNetUser.Name;
				userInDb.Email = aspNetUser.Email;
				userInDb.BirthDate = aspNetUser.BirthDate;
				userInDb.PhoneNumber = aspNetUser.PhoneNumber;
				userInDb.Street = aspNetUser.Street;
				userInDb.PostCode = aspNetUser.PostCode;
				userInDb.City = aspNetUser.City;
			}

			db.SaveChanges();

			return RedirectToAction("Index", "AspNetUsers");
		}


		public ActionResult Delete(string id)
		{
			var user = db.AspNetUsers.SingleOrDefault(u => u.Id == id);

			if (user == null)
				return HttpNotFound();

			return View("Delete", user);
		}

		[HttpPost]
		public ActionResult Delete2(AspNetUser user)
		{
			bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;

			try
			{
				db.Configuration.ValidateOnSaveEnabled = false;

				var userTemp = user;

				db.AspNetUsers.Attach(userTemp);
				db.Entry(userTemp).State = EntityState.Deleted;
				db.SaveChanges();
			}
			finally
			{
				db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
			}

			//db.Customers.Remove(customer);
			//db.SaveChanges();

			return RedirectToAction("Index", "AspNetUsers");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditUserInPanel(AspNetUser aspNetUser)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new AspNetUserFormViewModel
				{
					AspNetUser = aspNetUser,
				};

				return View("AspNetUserForm", viewModel);
			}

			if (aspNetUser.Id != "")
			{
				var userInDb = db.AspNetUsers.Single(u => u.Id == aspNetUser.Id);

				userInDb.Name = aspNetUser.Name;
				userInDb.Email = aspNetUser.Email;
				userInDb.BirthDate = aspNetUser.BirthDate;
				userInDb.PhoneNumber = aspNetUser.PhoneNumber;
				userInDb.Street = aspNetUser.Street;
				userInDb.PostCode = aspNetUser.PostCode;
				userInDb.City = aspNetUser.City;
			}

			db.SaveChanges();

			var user = db.AspNetUsers.SingleOrDefault(u => u.Id == aspNetUser.Id);
			
			var viewModel2 = new AspNetUserFormViewModel
			{
				AspNetUser = user,
			};

			return View("UserPanel", viewModel2);
			//return RedirectToAction("UserPanel", "AspNetUsers", aspNetUser.Id);

		}


		public ActionResult UserPanel(string id)
		{
			var user = db.AspNetUsers.SingleOrDefault(u => u.Id == id);

			var viewModel = new AspNetUserFormViewModel
			{
				AspNetUser = user,
			};

			return View("UserPanel", viewModel);
		}
	}
}
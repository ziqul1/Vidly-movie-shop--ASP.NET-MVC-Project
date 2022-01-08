using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyBest.Models;

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
	}
}
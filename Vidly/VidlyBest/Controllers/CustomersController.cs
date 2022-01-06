using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyBest.Models;
using System.Data.Entity;
using System.Net;
using VidlyBest.ViewModels;

namespace VidlyBest.Controllers
{
	[Authorize]
	public class CustomersController : Controller
	{
		private MyDbContext db = new MyDbContext();

		public ActionResult Index()
		{
			if (User.IsInRole(RoleName.CanManageMovies))
			{
				var customers = db.Customers.Include(c => c.MembershipType).ToList();
				return View(customers);
			}

			return RedirectToAction("Index", "Info");
		}

		public ActionResult Details(int id)
		{
			var customer = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		public ActionResult New()
		{
			var membershipTypes = db.MembershipTypes.ToList();

			var viewModel = new CustomerFormViewModel
			{
				MembershipTypes = membershipTypes
			};

			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					Customer = customer,
					MembershipTypes = db.MembershipTypes.ToList()
				};

				return View("CustomerForm", viewModel);
			}

			if (customer.Id == 0)
				db.Customers.Add(customer);
			else
			{
				var customerInDb = db.Customers.Single(c => c.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}

			db.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = db.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = db.MembershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}

		public ActionResult Delete(int id)
		{
			var customer = db.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = db.MembershipTypes.ToList()
			};

			return View("Delete", viewModel);
		}

		[HttpPost]
		public ActionResult Delete2(Customer customer)
		{
			bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;

			try
			{
				db.Configuration.ValidateOnSaveEnabled = false;

				var customerTemp = customer;

				db.Customers.Attach(customerTemp);
				db.Entry(customerTemp).State = EntityState.Deleted;
				db.SaveChanges();
			}
			finally
			{
				db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
			}

			//db.Customers.Remove(customer);
			//db.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}
	}
}
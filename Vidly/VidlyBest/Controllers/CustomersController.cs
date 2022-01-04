﻿using System;
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
	public class CustomersController : Controller
	{
		private MyDbContext db = new MyDbContext();

		public ViewResult Index()
		{
			return View();
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
	}
}
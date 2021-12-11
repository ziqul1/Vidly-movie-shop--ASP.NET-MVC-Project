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
    public class CustomersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ViewResult Index()
        {
            var customers = db.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
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
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
		}
    }
}
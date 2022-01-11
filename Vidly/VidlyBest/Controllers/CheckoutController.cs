using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyBest.Models;

namespace VidlyBest.Controllers
{
	public class CheckoutController : Controller
	{
		private MyDbContext db = new MyDbContext();


		//
		// GET: /Checkout/AddressAndPayment
		public ActionResult AddressAndPayment2()
		{
			return View("AddressAndPayment");
		}

		// GET: Checkout
		public ActionResult Index()
		{

			return View();
		}

		//
		// POST: /Checkout/AddressAndPayment
		[HttpPost]
		public ActionResult AddressAndPayment(FormCollection values, Order order2)
		{
			var order = new Order();

			var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);

			TryUpdateModel(order);

			try
			{
				order.Username = user.Email;
				order.OrderDate = DateTime.Now;
				order.FirstName = user.Name;
				order.Address = user.Street;
				order.City = user.City;
				order.PostalCode = user.PostCode;
				order.Phone = user.PhoneNumber;
				order.Total = order2.Total;
				
				//Save Order
				db.Orders.Add(order);
				db.SaveChanges();
				//Process the order
				var cart = ShoppingCart.GetCart(this.HttpContext);
				cart.CreateOrder(order);

				return RedirectToAction("Complete",
					new { id = order.OrderId });
			}
			catch
			{
				//Invalid - redisplay with errors
				return View(order);
			}
		}

		
		// GET: /Checkout/Complete
		public ActionResult Complete(int id)
		{
			// Validate customer owns this order
			bool isValid = db.Orders.Any(
				o => o.OrderId == id &&
				o.Username == User.Identity.Name);

			if (isValid)
			{
				return View(id);
			}
			else
			{
				return View("Error");
			}
		}
	}
}
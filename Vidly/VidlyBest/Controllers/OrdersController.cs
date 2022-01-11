using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyBest.Models;

namespace VidlyBest.Controllers
{
    public class OrdersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.ToList();

            return View("Index", orders);
        }

        public ActionResult Details(int id)
        {
            var orderDetails = db.OrderDetails.ToList().Where(o => o.OrderId == id).ToList();

            return View("Details", orderDetails);
        }
    }
}
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

        public ActionResult Index()
        {
            var orders = db.Orders.ToList();

            return View("Index", orders);
        }
    }
}
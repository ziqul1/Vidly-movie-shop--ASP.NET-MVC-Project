using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using VidlyBest.Models;

namespace VidlyBest
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private MyDbContext db = new MyDbContext();

		protected void Application_Start(Object sender, EventArgs e)
		{
			var visitors = db.Visitors.Single(m => m.Name == "TotalUser");
			int Number = visitors.Number;
			
			Application["Totaluser"] = Number;
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Session_Start()
		{
			Application.Lock();

			Application["Totaluser"] = (int)Application["Totaluser"] + 1;

			var visitors = db.Visitors.Single(m => m.Name == "TotalUser");
			var visitorsInDb = db.Visitors.Single(m => m.Name == "TotalUser");
			
			int Number = visitors.Number;
			Number += 1;
			visitorsInDb.Number = Number;
			
			db.SaveChanges();

			Application.UnLock();
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyBest.Models
{
	public class Order
	{
		public int? Id { get; set; }

		public string Products { get; set; }

		public string UserData { get; set; }
	}
}
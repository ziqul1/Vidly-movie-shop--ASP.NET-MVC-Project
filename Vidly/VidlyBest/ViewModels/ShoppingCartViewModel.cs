using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyBest.Models;

namespace VidlyBest.ViewModels
{
	public class ShoppingCartViewModel
	{
		public decimal CartTotal { get; set; }

		public List<Cart> CartItems { get; set; }
	}
}
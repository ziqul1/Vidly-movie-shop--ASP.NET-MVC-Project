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
		//public Cart CartItems2 { get; set; }
		public decimal CartTotal { get; set; }

		public List<Cart> CartItems { get; set; }

		//public Cart Cart { get; set; }


		//[Key]
		//public int RecordId { get; set; }
		//public string CartId { get; set; }
		//public int MovieId { get; set; }
		//public int Count { get; set; }
		//public System.DateTime DateCreated { get; set; }
		//public virtual Movie Movie { get; set; }

		//public ShoppingCartViewModel
	}
}
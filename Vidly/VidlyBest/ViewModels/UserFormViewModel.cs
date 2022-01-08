using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyBest.Models;

namespace VidlyBest.ViewModels
{
	public class UserFormViewModel
	{
		public IEnumerable<ApplicationUser> Users { get; set; }

		public ApplicationUser User { get; set; }

		public UserFormViewModel(ApplicationUser user)
		{
			
		}
	}
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyBest.Models
{
	public class AspNetUser
	{
		public string Id { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string UserName { get; set; }

		public string DrivingLicense { get; set; }

		public string Name { get; set; }

		public string Street { get; set; }

		public string PostCode { get; set; }

		public string City { get; set; }

		public DateTime? BirthDate { get; set; }
	}
}
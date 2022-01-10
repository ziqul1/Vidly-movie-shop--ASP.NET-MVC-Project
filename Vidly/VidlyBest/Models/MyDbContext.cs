using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VidlyBest.Models
{
	public class MyDbContext : DbContext
	{
		public MyDbContext() : base("MyCS") { }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Movie> Movies { get; set; }

		public DbSet<MembershipType> MembershipTypes { get; set; }

		public DbSet<Genre> Genres { get; set; }

		public DbSet<VisitorNumber> Visitors { get; set; }

		public DbSet<AspNetUser> AspNetUsers { get; set; }

		public DbSet<Cart> Carts { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails{ get; set; }
	}


}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using VidlyBest.Models;
using System.Data.Entity;

namespace VidlyBest.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }

		public IEnumerable<Movie> Movies { get; set; }

		public Movie Movie { get; set; }

		public int? Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte? GenreId { get; set; }

		[Display(Name = "Release Date")]
		[Required]
		public DateTime? ReleaseDate { get; set; }

		[Display(Name = "Date Added")]
		[Required]
		public DateTime? DateAdded { get; set; }

		[Required]
		[Range(1, 20)]
		[Display(Name = "Number in Stock")]
		public byte? NumberInStock { get; set; }

		[Required]
		[StringLength(int.MaxValue)]
		public string Description { get; set; }

		[Required]
		public int Price { get; set; }

		public string Title
		{
			get
			{
				return Id != 0 ? "Edit Movie" : "New Movie";
			}
		}

		public MovieFormViewModel()
		{
			Id = 0;
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			DateAdded = movie.DateAdded;
			NumberInStock = movie.NumberInStock;
			GenreId = movie.GenreId;
			Description = movie.Description;
			Movie = movie;
			Price = movie.Price;
		}
	}
}
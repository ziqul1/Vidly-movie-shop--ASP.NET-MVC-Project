using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace VidlyBest.Models
{
	public class Movie
	{
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        
        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1,20)]
        [Display(Name="Number in Stock")]
        public byte NumberInStock { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [Required]
		public int Price { get; set; }
	}
}
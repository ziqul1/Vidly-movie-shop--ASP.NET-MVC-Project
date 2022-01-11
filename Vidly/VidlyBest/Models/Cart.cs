using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyBest.Models
{
	public class Cart
	{
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int MovieId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
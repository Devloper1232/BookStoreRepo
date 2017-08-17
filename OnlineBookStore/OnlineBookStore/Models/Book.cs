using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public double Price { get; set; }
        public long UnitsAvailable { get; set; }
        public int CategoryId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string PreviewUrl { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
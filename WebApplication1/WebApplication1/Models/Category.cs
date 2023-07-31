using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Enter the CategoryName")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
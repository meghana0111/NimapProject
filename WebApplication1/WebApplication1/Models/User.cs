using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter the username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter the Password")]
        public string Password { get; set; }
    }
}
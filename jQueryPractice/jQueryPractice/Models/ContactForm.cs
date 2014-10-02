using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace jQueryPractice.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage="Enter your name"), Display(Name="Your Name")]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string Message { get; set; }

    }
}
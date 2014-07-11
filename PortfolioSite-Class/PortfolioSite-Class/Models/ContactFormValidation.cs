using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add using statement for data annotations
using System.ComponentModel.DataAnnotations;

namespace PortfolioSite_Class.Models
{
    //add the metadata type to the contact form
    [MetadataType(typeof(ContactFormValidation))]
    public partial class ContactForm
    {
        //nothing goes here
    }

    public class ContactFormValidation
    {
        //data annotations handle the label display of our
        // fields and set the requirments for valid data.
        [Required(ErrorMessage="You need a name")
        , Display(Name="Your Name")
        , MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)
        ,Display(Name="Company Name")]
        public string CompanyName { get; set; }

        [Required
        , EmailAddress(ErrorMessage="Your email need to be something@something.com")
        ,MaxLength(50)]
        public string Email { get; set; }

        [Required
        ,DataType(DataType.MultilineText)
        ,MaxLength(500)]
        public string Comments { get; set; }
    }
}
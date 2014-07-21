using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add a using statement for data annotations
using System.ComponentModel.DataAnnotations; 

namespace Week5CodeChallenge.Models
{
    //create a partial class for ContactForm
    // so we can connect the validation properties with
    // MetaData
    [MetadataType(typeof(ContactFormValidation))]
    public partial class ContactForm
    {
    }

    public class ContactFormValidation
    {
        [Required
        , Display(Name="First Name")
        , MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required
        ,Display(Name="Last Name")
        , MaxLength(50)]
        public string LastName { get; set; }

        [Required
        ,Display(Name="Email")
        , MaxLength(50)
        ,DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required
        , Display(Name = "Phone Number")
        , MaxLength(50)]
        public string Phone { get; set; }

        [Required
        , Display(Name = "Company Name")
        , MaxLength(50)]
        public string CompanyName { get; set; }


        [Required
, Display(Name = "Project Description")
, MaxLength(50)]
        public string ProjectDescription { get; set; }

        [Required
        , Display(Name = "Comments")
        , MaxLength(2000)
        , DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        
    }
}
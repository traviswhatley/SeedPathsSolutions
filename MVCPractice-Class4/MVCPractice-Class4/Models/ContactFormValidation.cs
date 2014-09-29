using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//step 1: import System.ComponentModel.DataAnnotations
using System.ComponentModel.DataAnnotations;

namespace MVCPractice_Class4.Models
{
    //step 2: create a partial class for the 
    // class we are trying to validate
    //step 3.  Add the data annotation for the
    // metadataType to be the validation class
    [MetadataType(typeof(ContactFormValidation))]
    public partial class ContactForm
    {
    }

    public class ContactFormValidation
    {
        //STEP 4: Declare the properties of the
        // class you want to validate, and set
        // data annotations
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
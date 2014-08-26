using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    [MetadataType(typeof(ImageValidation))]
    public partial class Image {}

    public class ImageValidation
    {
        public string ImageURL {get;set;}

    }


    public class Checkout
    {
        public Address Shipping { get; set; }
        public Address Billing { get; set; }
        public Payment Payment { get; set; }
    }
}
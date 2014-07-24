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
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //step 1: add using for data annotations

namespace eCommerce.Models
{
    //step 3: add metadata type data annotation
    [MetadataType(typeof(CategoryValidation))]
    public partial class Category { } //step 2: create the public partial class for the class we want to add metadata for

    public class CategoryValidation
    {
        //step 4: Get the properties from the .emdx > .tt > Category.cs file
        
        //step 5: Fill in the Data Annotations for the properties
        [Required, MaxLength(100), Display(Name="Category Name")]
        public string Name { get; set; }

        [Display(Name="Parent Category")]
        public Nullable<int> ParentID { get; set; }
    }
}
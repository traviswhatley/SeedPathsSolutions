using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add the using for data annotations
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    //new to declare a partial class of what we want to validate
    //set the metadata type to post validation
    [MetadataType(typeof(PostValidation))]
    public partial class Post
    {

    }

    public class PostValidation
    {
        [Required, DataType(DataType.MultilineText)]
        public string Body { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(200), DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }
        
    }
}
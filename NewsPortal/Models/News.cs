using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Models
{
    public class News
    {
       

        [Key]
        public int NewsId { get; set; }
        [Required(ErrorMessage = "Title  field is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Status field  is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please upload an image")]
      

        [Display(Name = "Image")]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Description field is required")]
      
        public string Description { get; set; }
        [Required]
        [DisplayName("Defined")]
        public bool  ToBeDefined { get; set; }
        public int CategoryId  { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Category  Category { get; set; }

        public ICollection<NewsComments> NewsComments { get; set; }

       
    }
}
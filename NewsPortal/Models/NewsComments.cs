using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class NewsComments
    {


        [Key]
        public int NewsCommentId { get; set; }
        [Required]

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Full Name  field can't be blank")]

        public string FullName { get; set; }

        [Required(ErrorMessage = "Description  field can't be blank")]
        public string  Description { get; set; }
        public virtual News News { get; set; }
        [Required]
        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
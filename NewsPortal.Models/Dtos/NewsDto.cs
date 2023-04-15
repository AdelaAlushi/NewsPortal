using NewsPortal.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.Dtos
{
    public class NewsDto
    {

        [Key]
        public int NewsId { get; set; }
        [Required(ErrorMessage = "Title  field is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Status field  is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please upload an image")]



        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Description field is required")]

        public string Description { get; set; }
        [Required]
        public bool ToBeDefined { get; set; }
        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<NewsComments> NewsComments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.DomainModels
{
    public class NewsComments
    {
        [Key]
        public int NewsCommentId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Comment  field can't be blank")]

        public string Comment { get; set; }

        public virtual News News { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

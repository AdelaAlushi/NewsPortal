using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.DomainModels
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name  field is required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please upload an Image")]

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Status  field is required")]

        public bool Status { get; set; }

        public ICollection<News> News { get; set; }
    }
}

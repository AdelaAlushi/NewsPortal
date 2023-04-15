using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryUrl { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
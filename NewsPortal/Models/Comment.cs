using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public partial class Comment
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public string Username { get; set; }
        public System.DateTime CommentDate { get; set; }
        public int ParentId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.DomainModels
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

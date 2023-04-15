using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.Dtos
{
    public class CommentDto
    {

        public int parentId { get; set; }
        public string commentText { get; set; }
        public string username { get; set; }
    }

    public class commentViewModel : CommentDto
    {
        public int commentId { get; set; }
        public DateTime commentDate { get; set; }
        public string strCommentDate { get {; return this.commentDate.ToString("dd-MM-yyyy"); } }
    }
}

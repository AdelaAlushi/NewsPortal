using NewsPortal.Models;
using NewsPortal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Repository
{
    public class CommentRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IQueryable<Comment> GetAll()
        {
            return context.Comments.OrderBy(x => x.CommentDate);
        }

        public commentViewModel AddComment(CommentDto comment)
        {
            var _comment = new Comment()
            {
                ParentId = comment.parentId,
                CommentText = comment.commentText,
                Username = comment.username,
                CommentDate = DateTime.Now
            };

            context.Comments.Add(_comment);
            context.SaveChanges();
            return context.Comments.Where(x => x.CommentID == _comment.CommentID)
                    .Select(x => new commentViewModel
                    {
                        commentId = x.CommentID,
                        commentText = x.CommentText,
                        parentId = x.ParentId,
                        commentDate = x.CommentDate,
                        username = x.Username

                    }).FirstOrDefault();
        }

    }
}
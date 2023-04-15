using NewsPortal.Models.Dtos;
using NewsPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        CommentRepository repo = new CommentRepository();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CommentPartial()
        {
            var comments = repo.GetAll();
            return PartialView("_CommentPartial", comments);
        }

      
    }
}
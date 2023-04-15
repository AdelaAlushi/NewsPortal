using NewsPortal.BLL.Interfaces;
using NewsPortal.DAL.Interfaces;

using NewsPortal.Models;
using NewsPortal.Models.Dtos;
using NewsPortal.Repository;
using NewsPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
   

    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly INewsService _newsService;


        private readonly INewsRepository _newsRepository;
        public HomeController()
        {
        }

        public HomeController(INewsRepository newsRepository, INewsService newsService)
        {
            newsRepository = _newsRepository;
            newsService = _newsService;
        }

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        //public ActionResult Index()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var news = db.News.ToList();
        //        //ViewBag.News = news;


        //    }
        //  return View(_newsService.ToString());
        //}
        public JsonResult GetMainMenu()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            {

                var menu = db.Categories.Select(c => new
                {

                    c.Name,
                    c.Status,
                    SubCategory = c.SubCategories.Select(s => new
                    {
                        s.SubCategoryId,

                        s.SubCategoryName,
                        s.SubCategoryUrl
                    })

                });

                return new JsonResult { Data = menu, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
        }
        [HttpGet]
        public ActionResult GetPosts()
        {
            IQueryable<News> Posts = db.News
                                                 .Select(p => new News
                                                 {
                                                     Title = p.Title,
                                                     Image= p.Image,
                                                     
                                                 }).AsQueryable();

            return View(Posts);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


   
        public ActionResult Index()
        {


            return View(db.News.ToList());
        }

        [HttpGet]


        public async Task<ActionResult> News(int? id)
          {

            if (id == null)
            {

                return HttpNotFound();

            }
               News news = await db.News.Where(x => x.NewsId == id).FirstOrDefaultAsync();

          if (news == null)

            {

                return HttpNotFound();

            }
            return View(news);

        }

        CommentRepository repo = new CommentRepository();
      

        public PartialViewResult CommentPartial()
        {
            var comments = repo.GetAll();
            return PartialView("_CommentPartial", comments);
        }

        public JsonResult addNewComment(CommentDto comment)
        {
            try
            {
                var model = repo.AddComment(comment);

                return Json(new { error = false, result = model }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

            }

            return Json(new { error = true }, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Destinations()
        {
          
            return View(db.News.ToList());

        }
        public ActionResult Technology()
        {

            return View(db.News.ToList());

        }
        public ActionResult Sport()
        {

            return View(db.News.ToList());

        }
        public ActionResult Trends()
        {

            return View(db.News.ToList());

        }
        public ActionResult Magazine()
        {

            return View(db.News.ToList());

        }
        public ActionResult _DisplayPartial()
        {
            return View();
        }
    }
}
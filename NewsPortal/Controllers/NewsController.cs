
using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{

   
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News

        public ActionResult Index()
        {
            return View(db.News.ToList());
        }


       
        [HttpGet]

        public ActionResult Create()
          {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
          
            return View();
          }


       
        [HttpPost]
        public ActionResult Create( News news )
            {
            string fileName = Path.GetFileNameWithoutExtension(news.ImgFile.FileName);
            string extension = Path.GetExtension(news.ImgFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            news.Image = "../NewsImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("../NewsImages/"), fileName);

            news.ImgFile.SaveAs(fileName);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.News.Add(news);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", news.CategoryId);
            return View(news);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", news.CategoryId);
            return View(news);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,Title,Status,Image,Description,ToBeDefined,CategoryId,UserId")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","News");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", news.CategoryId);
            return View(news);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index", "News");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
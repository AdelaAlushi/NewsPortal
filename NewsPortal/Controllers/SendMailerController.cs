using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewsPortal.Controllers
{
    public class SendMailerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SendMailer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MailPassword mailModel)
        {
            using (MailMessage mail = new MailMessage())
            {
                string numbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@#$%^&*()-=";
                Random objrandom = new Random();
                string passwordString = "";
                string strrandom = string.Empty;
                for (int i = 0; i < 8; i++)
                {
                    int temp = objrandom.Next(0, numbers.Length);
                    passwordString = numbers.ToCharArray()[temp].ToString();
                    strrandom += passwordString;
                }
                ViewBag.strongpwd = strrandom;

                mail.From = new MailAddress("adelaalushi97@gmail.com");
                mail.To.Add("somebody@domain.com");
                mail.Subject = "Login Password";
                mail.Body = "<h1>Hello</h1>. Your password for your account is "+strrandom ;
                mail.IsBodyHtml = true;


                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("adelaalushi97@gmail.com", "4989adela");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            return View();
        }
        
    }
}
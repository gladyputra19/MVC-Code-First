using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MVC_Code_First.Models;
using MVC_Code_First.Util;
using System.Net;

namespace MVC_Code_First.Controllers
{
    public class LoginsController : Controller
    {
        ApplicationDbContext MyContext = new ApplicationDbContext();
        // GET: Logins
        public ActionResult Index()
        {
            var list = MyContext.Logins.ToList();
            return View(list);
        }
        // GET: LoginView
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //public ActionResult Login( string Email,string Password)
        //{
        //    return View();
        //}
        // GET: RegisterView
        public ActionResult Register()
        {

            return View();

        }

        // GET: Logins/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        [HttpPost]
        public ActionResult Login(Login login)
        {
            var slog = MyContext.Logins.Where(e => e.Email == login.Email).SingleOrDefault();
            if (slog != null)
            {
                var myPassword = Hashing.validatePassword(login.Password, slog.Password);
                if (myPassword == true)
                {
                    Session["Email"] = login.Email;
                    Session.Add("Email", login.Email);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Login");

            }
            return RedirectToAction("Login");
           
        }
        [HttpPost]
        public ActionResult Register(Login register)
        {
            try
            {

                register.Password = Hashing.hashPassword(register.Password);
                MyContext.Logins.Add(register);
                var result = MyContext.SaveChanges();
                if (result == 2)
                {
                    MailMessage sMail = new MailMessage();
                    sMail.To.Add(new MailAddress(register.Email));
                    sMail.From = new MailAddress("cobamvc@gmail.com");
                    sMail.Subject = "[Password] " + DateTime.Now.ToString("ddMMyyyyhhmmss");
                    sMail.Body = "Hello New User, \nThis Is Your Password : " + register.Password;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("cobamvc@gmail.com", "Bootcamp33");
                    smtp.Send(sMail);
                    Console.WriteLine("Password Has Been Sent To Your Reserved Email. Please Kindly To Check Your Email To Login");
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email is Empty");
                    return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                }
            }
            catch
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
            }
                
                
            
                
            
            
        }

        // GET: Logins/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Logins/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Logins/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

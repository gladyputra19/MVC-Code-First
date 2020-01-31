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
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVC_Code_First.Controllers
{
    public class LoginsController : Controller
    {
        ApplicationDbContext MyContext = new ApplicationDbContext();
        // GET: Logins
        public async Task<ActionResult> Index(Role role)
        {
            var list = await MyContext.Logins.ToListAsync();
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
        public async Task<ActionResult> Login(Login login)
        {
            var slog = await MyContext.Logins.Where(e => e.Email == login.Email).SingleOrDefaultAsync();
            if (slog != null)
            {
                var myPassword = Hashing.validatePassword(login.Password, slog.Password);
                if (myPassword == true)
                {
                    Session["Email"] = login.Email;
                    Session.Add("Email", login.Email);
                    return RedirectToAction("Index", "Dashboard");
                }
                return RedirectToAction("Index", "Dashboard");

            }
            return RedirectToAction("Login");
           
        }
        [HttpPost]
        public async Task<ActionResult> Register(Login register)
        {
            //try
            //{

                register.Password = Hashing.hashPassword(register.Password);
                var role = await MyContext.Roles.FirstOrDefaultAsync(b => b.Id == 2);
                register.Role = role;
                MyContext.Logins.Add(register);
                var result = MyContext.SaveChanges();
                if (result > 0)
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
            //}
            //catch
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
            //}
                
                
            
                
            
            
        }
        
        // GET: Logins/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = MyContext.Logins.Find(id);
            return View(edit);
        }

        // POST: Logins/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Login login)
        {
            try
            {
                // TODO: Add update logic here
                var edit = MyContext.Logins.Find(id);
                edit.Email = login.Email ;
                MyContext.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                MyContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logins/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var delete = await MyContext.Logins.FindAsync(id);
            return View(delete);
        }

        // POST: Logins/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var delete = MyContext.Logins.Find(id);
                MyContext.Logins.Remove(delete);
                MyContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

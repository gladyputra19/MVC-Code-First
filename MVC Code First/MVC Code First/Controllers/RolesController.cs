using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Code_First.Models;

namespace MVC_Code_First.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext MyContext = new ApplicationDbContext();   
        // GET: Roles
        public ActionResult Index()
        {
            var list = MyContext.Roles.ToList();
            return View(list);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            var list = MyContext.Roles.Find(id);
            return View(list);
           
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {
            try
            {
                // TODO: Add insert logic here
                MyContext.Roles.Add(role);
                MyContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = MyContext.Roles.Find(id);
            return View(edit);
           
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Role role)
        {
            try
            {
                // TODO: Add update logic here
                var edit = MyContext.Roles.Find(id);
                edit.Name = role.Name;
                MyContext.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                MyContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = MyContext.Roles.Find(id);
            return View(delete);
          
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Role role)
        {
            try
            {
                var delete = MyContext.Roles.Find(id);
                MyContext.Roles.Remove(delete);
                MyContext.SaveChanges();
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

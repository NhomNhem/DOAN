using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webdemofinal.Models;

namespace webdemofinal.Areas.Admin.Controllers
{
    public class AdmintrasitorController : Controller
    {
        // GET: Admin/Admin
        private AdminC db = new AdminC();

        // GET: AdminUsers
        public ActionResult Index()
        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");

            return View(db.AdminUsers.ToList());
        }

        // GET: AdminUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // GET: AdminUsers/Create
        public ActionResult Create()
        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");

            return View();
        }

        // POST: AdminUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameUser,RoleUser,PasswordUser")] AdminUser adminUser)

        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");
            if (adminUser.RoleUser == "admin")
            {
                if (ModelState.IsValid)
                {
                    db.AdminUsers.Add(adminUser);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {

                    return Content("Không hợp lệ,có thể do ID < 0 hoặc Trùng ID");
                }
            }
            if (ModelState.IsValid)
            {
                db.AdminUsers.Add(adminUser);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {

                return Content("Không hợp lệ,có thể do ID < 0 hoặc Trùng ID");
            }
        }

        // GET: AdminUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // POST: AdminUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameUser,RoleUser,PasswordUser")] AdminUser adminUser)
        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");

            if (ModelState.IsValid)
            {
                db.Entry(adminUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminUser);
        }

        // GET: AdminUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // POST: AdminUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Role"]?.ToString() != "admin") return RedirectToAction("ProductList", "Products");

            AdminUser adminUser = db.AdminUsers.Find(id);
            db.AdminUsers.Remove(adminUser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
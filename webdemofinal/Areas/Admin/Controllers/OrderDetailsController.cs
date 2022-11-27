using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemofinal.Models;

namespace webdemofinal.Areas.Admin.Controllers
{
    public class OrderDetailsController : Controller
    {
        AdminC db = new AdminC();
        public ActionResult Index()
        {
            return View(db.OrderDetails.ToList());   
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderDetail det)
        {
            try
            {
                db.OrderDetails.Add(det);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int id)
        {
            return View(db.OrderDetails.Where(s => s.ID == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(db.OrderDetails.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, OrderDetail det)
        {
            db.Entry(det).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.OrderDetails.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, OrderDetail det)
        {
            try
            {
                det = db.OrderDetails.Where(s => s.ID == id).FirstOrDefault();
                db.OrderDetails.Remove(det);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
    }
}
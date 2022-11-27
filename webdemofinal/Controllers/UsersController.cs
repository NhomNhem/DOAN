using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemofinal.Models;
namespace webdemofinal.Controllers
{
    public class UsersController : Controller
    {
        AdminC db = new AdminC();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(cust.EmailCus))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(cust.PhoneCus))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa

                var khachhang = db.Customers.FirstOrDefault(k => k.NameCus == cust.NameCus);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
                if (ModelState.IsValid)
                {
                    db.Customers.Add(cust);
                    db.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cust)
        {

            var check = db.Customers.Where(s => s.NameCus == cust.NameCus && s.PassCus ==
        cust.PassCus).FirstOrDefault();
           
       
            if (check == null) //không có KH
            {
                ViewBag.ErrorInfo = "Không có KH này";
                return View("LoginCus");
            }
            else
            { // Có tồn tại KH -> chuẩn bị dữ liệu đưa về lại ShowCart.cshtml
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["IDCus"] = check.IDCus;
                Session["PassCus"] = check.PassCus;
                Session["NameCus"] = check.NameCus;
                Session["PhoneCus"] = check.PhoneCus;
                // Quay lại trang giỏ hàng với thông tin cần thiết
                return RedirectToAction("ShowCart", "ShoppingCart");
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {   
            Session.Clear();//clear
            return RedirectToAction("ProductList","ProductCus");
        }
      



    }
}
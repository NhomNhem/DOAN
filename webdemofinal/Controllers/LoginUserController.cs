using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using webdemofinal.Models;
using System.EnterpriseServices.CompensatingResourceManager;


namespace webdemofinal.Controllers
{
    public class LoginUserController : Controller
    {
            AdminC db = new AdminC();
        // GET: LoginUser
        // Phương thức tạo view cho Login


        public ActionResult Index(int? chon)
        {

            return View();
        }
        // Xử lý tìm kiếm ID, password trong AdminUser và thông báo
        [HttpPost]
        public ActionResult LoginAcount(AdminUser _user, string chon)
        {
            var check = db.AdminUsers.Where(s => s.ID == _user.ID && s.PasswordUser ==
           _user.PasswordUser).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai Info";
                return View("Index");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = check.ID;
                Session["PasswodUser"] = check.PasswordUser;
                Session["Role"] = check.RoleUser;
                Session["NameCus"] = check.NameUser;
                Session["chon"] = chon;
                if (check.RoleUser == "admin")
                    return RedirectToAction("Index", "HomeAdmin", new {area = "Admin"});
                return View();  
            }
        }

    }
}

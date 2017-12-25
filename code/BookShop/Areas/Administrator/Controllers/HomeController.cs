using BookShop.Model;
using BookShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        AdminRepository adminRepo = null;
        public HomeController()
        {
            adminRepo = new AdminRepository();
        }

        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ADMIN admin = adminRepo.GetAll().SingleOrDefault(x => x.username == username && x.password == password && x.allowed == 1);
            if (admin!=null)
            {
                // Đăng nhập thành công
                Session["userid"] = admin.userid;
                Session["username"] = admin.username;
                Session["fullname"] = admin.fullname;
                Session["avatar"] = admin.avatar;

                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu !!!";
            return View();
        }

        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;

            return RedirectToAction("Login");
        }
    }
}
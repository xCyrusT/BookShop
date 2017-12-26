using BookShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        SachRepository sachRepo = null;
        ChuDeRepository chudeRepo = null;
        public HomeController()
        {
            sachRepo = new SachRepository();
            chudeRepo = new ChuDeRepository();
        }

        public ActionResult Index()
        {
            ViewBag.listSachMoi = sachRepo.GetAll().OrderByDescending(x => x.Ngaycapnhat).Take(4).ToList();
            ViewBag.listSachNoiBat = sachRepo.GetAll().OrderByDescending(x => x.Solanxem).Take(4).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult _PartialViewChuDe()
        {
            return PartialView(chudeRepo.GetAll());
        }
    }
}
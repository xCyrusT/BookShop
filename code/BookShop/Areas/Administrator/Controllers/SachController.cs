using BookShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Administrator.Controllers
{
    public class SachController : Controller
    {
        SachRepository sachRepo = null;
        ChuDeRepository chudeRepo = null;
        NhaXuatBanRepository nxbRepo = null;

        public SachController()
        {
            sachRepo = new SachRepository();
            chudeRepo = new ChuDeRepository();
            nxbRepo = new NhaXuatBanRepository();
        }

        // GET: Administrator/Sach
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(chudeRepo.GetAll(), "MaCD", "Tenchude");
            ViewBag.MaNXB = new SelectList(nxbRepo.GetAll(), "MaNXB", "TenNXB");
            return View();
        }
    }
}
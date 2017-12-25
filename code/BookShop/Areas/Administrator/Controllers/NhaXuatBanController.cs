using BookShop.Model;
using BookShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Administrator.Controllers
{
    public class NhaXuatBanController : Controller
    {
        NhaXuatBanRepository nxbRepo = null;
        public NhaXuatBanController()
        {
            nxbRepo = new NhaXuatBanRepository();
        }

        // GET: Administrator/NhaXuatBan
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(nxbRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(NHAXUATBAN nxb)
        {
            return Json(nxbRepo.Create(nxb), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            return Json(nxbRepo.Delete(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            NHAXUATBAN nxb = nxbRepo.GetAll().SingleOrDefault(x => x.MaNXB == id);
            return Json(nxb, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(NHAXUATBAN nxb)
        {
            return Json(nxbRepo.Update(nxb), JsonRequestBehavior.AllowGet);
        }
    }
}
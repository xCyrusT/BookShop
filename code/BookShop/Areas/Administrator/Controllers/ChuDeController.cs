using BookShop.Model;
using BookShop.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Administrator.Controllers
{
    public class ChuDeController : Controller
    {
        private ChuDeRepository chuDeRepo = new ChuDeRepository();

        // GET: Administrator/ChuDe
        public ActionResult Index()
        {
            var listChuDe = chuDeRepo.GetAll();
            return View(listChuDe);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CHUDE cd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chuDeRepo.Create(cd);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(cd);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                chuDeRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CHUDE cd = null;
            try
            {
                cd = chuDeRepo.GetAll().SingleOrDefault(x => x.MaCD == id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(cd);
        }
        [HttpPost]
        public ActionResult Edit(CHUDE cd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chuDeRepo.Update(cd);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(cd);
        }

        public ActionResult GetPaging(int? page)
        {
            int pageSize = 10; // Số sản phẩm của 1 trang
            int pageNum = (page ?? 1); // If(page==null)->set page==1

            return PartialView("_GetPaging", chuDeRepo.GetAll().ToPagedList(pageNum, pageSize));
        }
    }
}
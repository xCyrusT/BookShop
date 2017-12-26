using BookShop.Model;
using BookShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BookShop.Controllers
{
    public class SachController : Controller
    {
        SachRepository sachRepo = null;

        public SachController()
        {
            sachRepo = new SachRepository();
        }

        // GET: Sach
        public ActionResult Index(int id)
        {
            return View(sachRepo.GetAll().Where(x => x.MaCD == id).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(sachRepo.GetByID(id));
        }

        public ActionResult Search(string keyWord, int? page)
        {
            List<SACH> listSach = new List<SACH>();
            ViewBag.search = keyWord;
            if (!String.IsNullOrEmpty(keyWord))
            {
                listSach = sachRepo.GetAll().Where(x => x.Tensach.ToLower().Contains(keyWord.ToLower())).ToList();
            }

            int pageSize = 4;
            int pageNum = page ?? 1;

            return View(listSach.ToPagedList(pageNum, pageSize));
        }
    }
}
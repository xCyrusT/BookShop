using BookShop.Models;
using BookShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        SachRepository sachRepo = null;
        public CartController()
        {
            sachRepo = new SachRepository();
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            List<CartItem> giohang = null;

            if (Session["giohang"] == null) // Giỏ hàng trống
            {
                giohang = new List<CartItem>();
                giohang.Add(new CartItem() { ProductOrder = sachRepo.GetByID(id), Quantity = 1 });
            }
            else // Giỏ hàng đã có sản phẩm
            {
                giohang = (List<CartItem>)Session["giohang"];
                CartItem s = giohang.SingleOrDefault(x => x.ProductOrder.Masach == id);
                if (s != null)
                {
                    s.Quantity++; // Tăng số lượng thêm 1
                }
                else
                {
                    giohang.Add(new CartItem() { ProductOrder = sachRepo.GetByID(id), Quantity = 1 });
                }
            }

            // Cập nhật Session["giohang"]
            Session["giohang"] = giohang;
            return Json(new { ItemAmount = giohang.Sum(x => x.Quantity) });
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Helpers;
using DoAnFW.Models;
using Microsoft.AspNetCore.Mvc;


namespace DoAnFW.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.total = cart.Sum(item => item.SanPham.Gia * item.Quantity);
            ViewBag.cart = cart;


            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(int quantity, int MaSP)
        {
            StoreContext storeContext = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>(); //mảng các item



                cart.Add(new Item { SanPham = storeContext.find(MaSP), Quantity = quantity });



                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(MaSP);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { SanPham = storeContext.find(MaSP), Quantity = quantity });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");


        }
        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            StoreContext storeContext = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");


            var result = storeContext.Checkout(model, cart);
            if (result == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return BadRequest();
            }
        }
        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].SanPham.MaSP.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}









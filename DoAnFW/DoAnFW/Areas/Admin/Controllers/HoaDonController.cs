using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace DoAnFW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetHoaDons());
        }
        public IActionResult InsertHoaDon()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditHoaDon(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetHoaDonById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateHoaDon(HoaDon hd)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.UpdateHoaDon(hd);
            if (result > 0)
            {
                ViewData["result"] = "Cập nhập hóa đơn thành công";
                ViewBag.flat = 1;
            }
            else
            {
                ViewData["result"] = "Cập nhập hóa đơn thất bại!";
                ViewBag.flat = 0;
            }
            return View();
        }
        public IActionResult PrintHoaDon(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetCTHDs());

        }
        public IActionResult Invoice()
        {

            ViewBag.Date = DateTime.Now;
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            return View();
        }
    }
}
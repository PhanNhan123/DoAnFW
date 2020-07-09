using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public IActionResult EditHoaDon(HoaDon hd)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.UpdateHoaDon(hd);
            if (result > 0)
                ViewData["thongbao"] = "Sửa thành công";
            else
                ViewData["thongbao"] = "Sửa không thành công";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteHoaDon(string Id)
        {

            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            int count = context.DeleteHoaDon(Id);
            if (count > 0)
                ViewData["thongbao"] = "Xóa thành công";
            else
                ViewData["thongbao"] = "Xóa không thành công";
            return RedirectToAction("Index");
        }
    }
}
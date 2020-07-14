using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnFW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachHangController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;

            return View(context.GetKhachHangs());
        }
        public IActionResult EnterKhachHang()
        {
            return View();
        }
        public IActionResult InsertKhachHang(KhachHang kh)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;

            int count = context.InsertKhachHang(kh);
            if (count > 0)
            {
                ViewData["result"] = "Thêm thành công khách hàng " + kh.TenKH;
                ViewBag.flat = 1;
            }
            else
            {
                ViewData["result"] = "Thêm khách hàng thất bại";
                ViewBag.flat = 0;
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditKhachHang(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetKhachHangById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateKhachHang(KhachHang kh)
        {

            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.UpdateKhachHang(kh);
            if (result > 0)
            {
                ViewData["result"] = "Cập nhập thông tin khách hàng thành công";
                ViewBag.flat = 1;
            }
            else
            {
                ViewData["result"] = "Cập nhập thông tin khách hàng thất bại!";
                ViewBag.flat = 0;
            }
            return View();

        }


    }
}
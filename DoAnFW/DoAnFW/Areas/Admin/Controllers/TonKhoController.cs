using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAnFW.Models;

namespace DoAnFW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TonKhoController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;

            return View(context.GetSPTonKho());
        }
        [HttpGet]
        public IActionResult EditTonKho(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            ViewBag.sanpham = context.GetSanPhamById(id);
            return View(context.GetTonKhoID(id));
        }
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTonKHo(TonKho tk)
        {

            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.UpdateTonKHo(tk);
            if (result > 0)
            {
                ViewData["result"] = "Cập nhập số lượng tồn kho thành công";
                ViewBag.flat = 1;
            }
            else
            {
                ViewData["result"] = "Cập nhập số lượng tồn kho thất bại!";
                ViewBag.flat = 0;
            }
            return View();
        }
    }
}

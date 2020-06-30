using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace DoAnFW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetListSPAdmin());
        }

        public IActionResult InsertSanPham()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetNhanHieus());
        }
        [HttpPost]
        public IActionResult Form(string TenSP, string MaNH)
        {
            ViewData["Ten"] = TenSP;
            ViewData["MaNH"] = MaNH;
            return View();
        }
    }
}
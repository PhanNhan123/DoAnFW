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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnFW.Controllers
{
    public class HoaDonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("api/hoadon/gethd/{SDT}")]
        [HttpGet]
        public IActionResult GetHoaDonByPhone(string SDT)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            List<HoaDon> hd = context.GetHoaDonByPhone(SDT);
            return Ok(new
            {
                success = true,
                data = hd
            });
        }


        [Route("api/hoadon/getcthd/{id}")]
        [HttpGet]
        public IActionResult GetCTHD(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var hd = context.GetCTHDs(id);
            return Ok(new
            {
                success = true,
                data = hd
            });
        }
    }
}
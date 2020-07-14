using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnFW.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("api/auth/login")]
        [HttpPost]
        public IActionResult LoginMobile([FromBody] KhachHang kh)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            KhachHang khachhang = context.LoginMobile(kh.SDT, kh.matKhau);
            Console.WriteLine("khach hang" + kh.SDT + kh.matKhau);
            return Ok(new
            {
                success = true,
                data = khachhang
            });
        }
    }
}
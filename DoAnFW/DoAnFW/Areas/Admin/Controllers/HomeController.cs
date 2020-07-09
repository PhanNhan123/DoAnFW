using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Renci.SshNet;

namespace DoAnFW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        //HttpContext.Session.SetString("Tokens".result.ResultObject)
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;

            var uId = HttpContext.Session.GetString("idUser");
            if (uId != null)
            {
                DateTime dt = DateTime.Now;
                ViewBag.TotalCost = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0}", context.Total());
                ViewBag.ExpectedCost = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0}", context.ExpectedCost());
                ViewBag.NumberofCustomer = context.Num_Customer();
                ViewBag.TotalIteam = context.TotalSaleItem(dt.Month, dt.Year);
                ViewData["Name"] = HttpContext.Session.GetString("Name");
                ViewData["Username"] = HttpContext.Session.GetString("Username");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            ////return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            //HttpContext.Session.SetString("idUser",USERiD); 

            return View();
        }
        [HttpPost]
        public IActionResult CheckLogin(string username, string password)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            NguoiDung nd = context.Login(username, password);
            if (nd.Ma != 0)
            {
                HttpContext.Session.SetString("idUser", nd.Ma.ToString());
                HttpContext.Session.SetString("Username", nd.TaiKhoan);
                HttpContext.Session.SetString("Name", nd.Ten);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["message"] = "Sai tài khoản hoặc mật khẩu";
                return RedirectToAction("Login");
            }
        }
        public IActionResult GetBarChart()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.GetBarChart();

            return Json(result);
        }
        public IActionResult GetLineChart()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.GetLineChart();

            return Json(result);
        }
        public IActionResult GetPieChart()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.GetPieChart();
            return Json(result);

        }
        public IActionResult GetQuarterChart()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.GetQuarterChart();
            return Json(result);
        }
        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
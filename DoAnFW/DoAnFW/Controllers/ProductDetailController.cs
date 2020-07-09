using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAnFW.Helpers;
using DoAnFW.Models;


namespace DoAnFW.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(int MaSP)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;


            return View(context.find(MaSP));



        }


    }
}







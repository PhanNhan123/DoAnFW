
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAnFW.Models;




namespace DoAnFW.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            //ProductModel productModel = new ProductModel();
            ViewBag.products = context.findAll();
            ViewBag.top5products = context.top5();
            ViewBag.top2products = context.top2();
            return View();
        }

        [Route("/api/products/top5")]
        [HttpGet]
        public IActionResult GetTop5()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            List<SanPham> products = context.top5();

            return Ok(new
            {
                success = true,
                data = products
            });
        }

        [Route("/api/products")]
        [HttpGet]
        public IActionResult GetAll()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            List<SanPham> products = context.findAll();

            return Ok(new
            {
                success = true,
                data = products
            });
        }

        [Route("api/products/sreach")]
        [HttpGet]
        public IActionResult Sreach(string key)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            List<SanPham> products = context.Search(key);

            return Ok(new
            {
                success = true,
                data = products
            });
        }
    }
}


﻿
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
            return View();
        }
    }
}





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

        public IActionResult EnterSanPham()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetNhanHieus());
        }
        [HttpPost]
        public IActionResult InsertSanPham(string TenSP, string MaNH, string IMG, double Gia, int SoLuong, string MoTa, string TuongThich, string Jack_cam, string KichThuoc, string CongNghe, string TrongLuong)
        {
            SanPham t = new SanPham();
            t.TenSP = TenSP;
            t.MoTa = MoTa;
            t.IMG = IMG;
            t.MaNH = MaNH;
            t.Gia = Gia;
            t.TuongThich = TuongThich;
            t.Jack_cam = Jack_cam;
            t.KichThuoc = KichThuoc;
            t.CongNghe = CongNghe;
            t.TrongLuong = TrongLuong;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            int count = context.InsertSanPham(t);
            int id = 0;
            if (count > 0)
            {
                id = context.GetIDSanPham(t);
                if (context.InsertTonKho(id, SoLuong) != 0)
                { ViewBag.result = 1; }
            }
            else
            {
                ViewBag.result = 0;
            }
            return View();
        }

        public IActionResult EditSanPham(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            return View(context.GetSanPhamById(id));
        }

        public IActionResult DeleteSanPham(string Id)
        {
            string temp = Id;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            int count = context.DeleteSP_TonKho(Id);
            int flat = context.DeleteSanPham(Id);
            if (count != 0 && flat != 0)
            {
                ViewBag.result = "Xóa sản phẩm thành công";
            }
            else
            {
                ViewBag.result = "Xóa sản phẩm không thành công";
            }
            return View();

        }
    }
}
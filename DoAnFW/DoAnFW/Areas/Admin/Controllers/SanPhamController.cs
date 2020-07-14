using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DoAnFW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Hosting;

namespace DoAnFW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public SanPhamController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
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
        public IActionResult InsertSanPham(string TenSP, string MaNH, IFormFile IMG, double Gia, int SoLuong, string MoTa, string TuongThich, string Jack_cam, string KichThuoc, string CongNghe, string TrongLuong)
        {
            SanPham t = new SanPham();
            t.TenSP = TenSP;
            t.MoTa = MoTa;
            t.MaNH = MaNH;
            t.Gia = Gia;
            t.TuongThich = TuongThich;
            t.Jack_cam = Jack_cam;
            t.KichThuoc = KichThuoc;
            t.CongNghe = CongNghe;
            t.TrongLuong = TrongLuong;
            string uniqueFileName = null;
            var uploadFoder = Path.Combine(_hostingEnvironment.WebRootPath, "image");
            if (IMG.FileName == null)
            {
                return BadRequest("Vui lòng chọn ảnh");
            }
            uniqueFileName = Guid.NewGuid().ToString() + "_" + IMG.FileName;
            var filePath = Path.Combine(uploadFoder, uniqueFileName);
            IMG.CopyTo(new FileStream(filePath, FileMode.Create));
            t.IMG = uniqueFileName;


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
        [HttpGet]
        public IActionResult EditSanPham(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            ViewBag.nhanhieu = context.GetNhanHieus();
            return View(context.GetSanPhamById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSanPham(SanPham sp, IFormFile IMG)
        {
            string uniqueFileName = null;
            var uploadFoder = Path.Combine(_hostingEnvironment.WebRootPath, "image");
            if (IMG.FileName == null)
            {
                return BadRequest("Vui lòng chọn ảnh");
            }
            uniqueFileName = Guid.NewGuid().ToString() + "_" + IMG.FileName;
            var filePath = Path.Combine(uploadFoder, uniqueFileName);
            IMG.CopyTo(new FileStream(filePath, FileMode.Create));
            StoreContext context = HttpContext.RequestServices.GetService(typeof(DoAnFW.Models.StoreContext)) as StoreContext;
            var result = context.UpdateSanPham(sp, uniqueFileName);
            if (result > 0)
                ViewData["thongbao"] = "Sửa thành công";
            else
                ViewData["thongbao"] = "Sửa không thành công";
            return RedirectToAction("Index");
        }
        [HttpPost]
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
            return RedirectToAction("Index");

        }
    }
}
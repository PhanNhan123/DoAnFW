using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class SanPham
    {
        private int maSP;
        private string tenSP;
        private string maNH;
        private double gia;
        private string tuongThich;
        private string jack;
        private string kichThuoc;
        private string congNghe;
        private string trongLuong;

        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        public string MaNH
        {
            get { return maNH; }
            set { maNH = value; }
        }
        public double Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        public string TuongThich
        {
            get { return tuongThich; }
            set { tuongThich = value; }
        }

        public string Jack_cam
        {
            get { return jack; }
            set { jack = value; }
        }
        public string KichThuoc
        {
            get { return kichThuoc; }
            set { kichThuoc = value; }
        }
        public string CongNghe
        {
            get { return congNghe; }
            set { congNghe = value; }
        }
        public string TrongLuong
        {
            get { return trongLuong; }
            set { trongLuong = value; }
        }

    }

}

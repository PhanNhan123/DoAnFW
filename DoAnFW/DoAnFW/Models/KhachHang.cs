using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class KhachHang
    {
        private int maKH;
        private string tenKH;
        private string sDT;
        private string diaChi;

        public KhachHang()
        {

        }
        public KhachHang(int ma,string ten, string phone, string diachi)
        {
            maKH = ma;
            tenKH = ten;
            sDT = phone;
            diaChi = diachi;
        }

        public int MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }
        public string SDT
        {
            get { return sDT; }
            set { sDT = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
    }
}

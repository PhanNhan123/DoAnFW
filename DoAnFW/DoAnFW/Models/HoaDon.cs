using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class HoaDon
    {
        private int maHD;
        private int maNL;
        private int maKH;
        private DateTime ngayLap;
        private double tongGia;
        private string trangThai;

        public HoaDon() { }
        public HoaDon(int mahd, int manl, int makh,DateTime ngaylap,double tonggia,string tt)
        {
            maHD = mahd;
            maNL = manl;
            maKH = makh;
            ngayLap = ngaylap;
            tongGia = tonggia;
            trangThai = tt;
        }
        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        public int MaNL
        {
            get { return maNL; }
            set { maNL = value; }
        }
        public int MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        public double TongGia
        {
            get { return tongGia; }
            set { tongGia = value; }
        }
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
    }
}

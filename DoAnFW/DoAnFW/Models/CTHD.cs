using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class CTHD
    {
        private int maSP;
        private int maHD;
        private int soLuong;
        private int maKM;
        private string hTTT;

        public CTHD() { }
        public CTHD(int masp, int mahd , int soluong, int makm, string httt)
        {
            maSP = masp;
            maHD = mahd;
            soLuong = soluong;
            maKM = makm;
            hTTT = httt;
        }
        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public int MaKM
        {
            get { return maKM; }
            set { maKM = value; }
        }
        public string HTTT
        {
            get { return hTTT; }
            set { hTTT = value; }
        }
    }
}

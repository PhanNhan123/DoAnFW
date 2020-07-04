using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class TonKho
    {
        private int maKho;
        private int maSP;
        private int soLuongTon;
        public int MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        public int SoLuongTon
        {
            get { return soLuongTon; }
            set { soLuongTon = value; }
        }
    }
}

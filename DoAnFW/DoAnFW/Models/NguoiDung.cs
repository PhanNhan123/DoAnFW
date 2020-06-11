using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class NguoiDung
    {
        private int ma;
        private string ten;
        private string taiKhoan;
        private string matKhau;
        public NguoiDung()
        { }
        public NguoiDung(int maND, string tenND, string TK, string MK)
        {
            ma = maND;
            ten = tenND;
            taiKhoan = TK;
            matKhau = MK;
        }
        public int Ma 
        {
            get{ return ma; }
            set { ma = value; }
        }
        public string Ten
        {
            get { return ten; }
            set { ten= value;  }
        }
        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan=value;  }
        }
            public string MatKhau 
        {
            get { return matKhau; }
            set { matKhau= value ;  }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class NhanHieu
    {
        private string maNH;
        private string tenNH;
        private string noiSX;
        public NhanHieu() { }
        public NhanHieu(string ma, string ten, string NoiSX)
        {
            maNH = ma;
            tenNH = ten;
            noiSX = NoiSX;
        }
        public string MaNH
        {
            get { return maNH; }
            set { maNH = value; }
        }
        public string TenNH
        {
            get { return tenNH; }
            set { tenNH = value; }
        }
        public string NoiSX
        {
            get { return noiSX; }
            set { noiSX = value; }
        }
    }
}

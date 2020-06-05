using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class KhuyenMai
    {
        private int maKM;
        private string tenKM;
        private float tiLe;
        private DateTime ngayBD;
        private DateTime ngayKT;
         public KhuyenMai() { }
        public KhuyenMai(int ma, string ten , float tl,DateTime bd, DateTime kt)
        {
            maKM = ma;
            tenKM = ten;
            tiLe = tl;
            ngayBD = bd;
            ngayKT = kt;
        }
        public int MaKM
        {
            get { return maKM; }
            set { maKM = value; }
        }
        public string TenKM
        {
            get { return tenKM; }
            set { tenKM = value; }
        }
        public float TiLe
        {
            get { return tiLe; }
            set { tiLe = value; }
        }
        public DateTime NgayBD
        {
            get { return ngayBD; }
            set { ngayBD = value; }
        }
        public DateTime NgayKT
        {
            get { return ngayKT; }
            set { ngayKT = value; }
        }
    }
}
